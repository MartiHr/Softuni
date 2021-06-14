using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            List<Tire[]> tires = new List<Tire[]>();

            while ((command = Console.ReadLine()) != "No more tires")
            {
                string[] elements = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int year1 = int.Parse(elements[0]);
                double pressure1 = double.Parse(elements[1]);
                int year2 = int.Parse(elements[2]);
                double pressure2 = double.Parse(elements[3]);
                int year3 = int.Parse(elements[4]);
                double pressure3 = double.Parse(elements[5]);
                int year4 = int.Parse(elements[6]);
                double pressure4 = double.Parse(elements[7]);

                Tire currentTire1 = new Tire(year1, pressure1);
                Tire currentTire2 = new Tire(year2, pressure2);
                Tire currentTire3 = new Tire(year3, pressure3);
                Tire currentTire4 = new Tire(year4, pressure4);
                Tire[] currentTires = new Tire[4]
                {
                    currentTire1,
                    currentTire2,
                    currentTire3,
                    currentTire4
                };

                tires.Add(currentTires);
            }

            string secondCommand = string.Empty;

            List<Engine> engines = new List<Engine>();

            while ((secondCommand = Console.ReadLine()) != "Engines done")
            {
                string[] elements = secondCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(elements[0]);
                double cubicCapacity = double.Parse(elements[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);

                engines.Add(currentEngine);
            }

            string thirdCommand = string.Empty;

            List<Car> cars = new List<Car>();

            while ((thirdCommand = Console.ReadLine()) != "Show special")
            {
                string[] elements = thirdCommand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = elements[0];
                string model = elements[1];
                int year = int.Parse(elements[2]);
                double fuelQuantity = double.Parse(elements[3]);
                double fuelConsumption = double.Parse(elements[4]) / 100;
                int engineIndex = int.Parse(elements[5]);
                int tiresIndex = int.Parse(elements[6]);

                Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption,
                    engines[engineIndex], tires[tiresIndex]);

                cars.Add(currentCar);
            }

            List<Car> filteredCars = cars
                .Where(x => x.Year == 2017 && x.Engine.HorsePower > 330 &&
                GetSumOfTires(x.Tires) > 9 && GetSumOfTires(x.Tires) < 10)
                .ToList();

            foreach (var car in filteredCars)
            {
                double newFuelQuanity = Drive(20, car.FuelQuantity, car.FuelConsumption);

                car.FuelQuantity = newFuelQuanity;
            }

            foreach (var specialCar in filteredCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }

        public static double Drive(double distance, double fuelQuantity, double fuelConsumption)
        {
            if (fuelQuantity - distance * fuelConsumption > 0)
            {
                fuelQuantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }

            return fuelQuantity;
        }

        public static double GetSumOfTires(Tire[] tires)
        {
            double sum = 0.0;

            foreach (var tire in tires)
            {
                sum += tire.Pressure;
            }

            return sum;
        }
    }
}
