using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    public class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split();

                Vehicle currentVehicle = new Vehicle()
                { 
                    Type = data[0],
                    Model = data[1],
                    Color = data[2],
                    Horsepower = int.Parse(data[3]),
                };

                catalogue.Add(currentVehicle);
            }

            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    break;
                }

                Vehicle vehicle = GetVehicleByModel(catalogue, model);

                if (vehicle == null)
                {
                    continue;
                }

                if (vehicle.Type == "car")
                {
                    Console.WriteLine("Type: Car");
                }
                else
                {
                    Console.WriteLine("Type: Truck");
                }
                
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
            }

            

            double averageHorsepowersCar = CalcAvgHorsePowerByType(catalogue, "car");
            double averageHorsepowersTruck = CalcAvgHorsePowerByType(catalogue, "truck");
            

            Console.WriteLine($"Cars have average horsepower of: {averageHorsepowersCar:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHorsepowersTruck:f2}.");
        }

        private static double CalcAvgHorsePowerByType(List<Vehicle> catalogue, string type)
        {
            int typeHorsepowerSum = 0;
            int typeCount = 0;

            foreach (var vehicle in catalogue)
            {
                if (vehicle.Type == type)
                {
                    typeHorsepowerSum += vehicle.Horsepower;
                    typeCount++;
                }
            }

            if (typeCount == 0)
            {
                return 0;
            }
           
            return (double)typeHorsepowerSum / typeCount;
        }

        private static Vehicle GetVehicleByModel(List<Vehicle> catalogue, string model)
        {
            foreach (var vehicle in catalogue)
            {
                if (vehicle.Model == model)
                {
                    return vehicle;
                }
            }

            return null;
        }
    }
}
