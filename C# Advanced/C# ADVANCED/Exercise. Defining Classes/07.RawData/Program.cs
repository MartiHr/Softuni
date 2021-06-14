using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = elements[0];
                
                int engineSpeed = int.Parse(elements[1]);
                int enginePower = int.Parse(elements[2]);

                Engine engine = new Engine
                {
                    EnginePower = enginePower,
                    EngineSpeed = engineSpeed
                };

                int cargoWeight = int.Parse(elements[3]);
                string cargoType = elements[4];

                Cargo cargo = new Cargo
                {
                    CargoWeight = cargoWeight,
                    CargoType = cargoType
                };

                double tire1Pressure = double.Parse(elements[5]);
                int tire1Age = int.Parse(elements[6]);
                double tire2Pressure = double.Parse(elements[7]);
                int tire2Age = int.Parse(elements[8]);
                double tire3Pressure = double.Parse(elements[9]);
                int tire3Age = int.Parse(elements[10]);
                double tire4Pressure = double.Parse(elements[11]);
                int tire4Age = int.Parse(elements[12]);

                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                };

                Car currentCar = new Car(model, engine, cargo, tires);

                cars.Add(currentCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                HashSet<Car> fragileCars = cars
                    .Where(x => x.Cargo.CargoType == "fragile")
                    .Where(x => TiresPressurexIfBelow1(x.Tires))
                    .ToHashSet();

                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                HashSet<Car> flamableCars = cars
                    .Where(x => x.Cargo.CargoType == "flamable")
                    .Where(x => x.Engine.EnginePower > 250)
                    .ToHashSet();

                foreach (var car in flamableCars)
                {
                    Console.WriteLine(car.Model); ;
                }
            }
        }

        private static bool TiresPressurexIfBelow1(Tire[] tires)
        {
            foreach (var tire in tires)
            {
                if (tire.TirePressure < 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
