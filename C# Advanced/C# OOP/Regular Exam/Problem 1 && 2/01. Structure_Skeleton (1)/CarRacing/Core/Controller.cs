using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IRepository<ICar> cars;
        private IRepository<IRacer> racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            if (type == "SuperCar")
            {
                SuperCar superCar = new SuperCar(make, model, VIN, horsePower);
                cars.Add(superCar);
            }
            else if (type == "TunedCar")
            {
                TunedCar tunedCar = new TunedCar(make, model, VIN, horsePower);
                cars.Add(tunedCar);
            }


            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            bool success = false;

            foreach (var model in cars.Models)
            {
                if (model.VIN == carVIN)
                {
                    success = true;
                }
            }

            if (success == false)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            if (type == "ProfessionalRacer")
            {
                var car = cars.Models.FirstOrDefault(x => x.VIN == carVIN);
                ProfessionalRacer professionalRacer = new ProfessionalRacer(username, car);

            }
            else if (type == "StreetRacer")
            {
                var car = cars.Models.FirstOrDefault(x => x.VIN == carVIN);
                StreetRacer professionalRacer = new StreetRacer(username, car);
            }

            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            IRacer secondRacer = racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);

            if (firstRacer == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }

            if (secondRacer == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return map.StartRace(firstRacer, secondRacer);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var model in racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine($"{model.GetType().Name}: {model.Username}");
                sb.AppendLine($"--Driving behavior: {model.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {model.DrivingExperience}");
                sb.AppendLine($"--Car: {model.Car.Make} {model.Car.Model} ({model.Car.VIN})");
            }

            return sb.ToString().Trim();
        }
    }
}
