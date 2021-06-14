using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                bool uniqueModel = true;

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        uniqueModel = false;
                    }
                }

                if (uniqueModel)
                {
                    Car currentCar = new Car
                    {
                        Model = model,
                        FuelAmount = fuelAmount,
                        FuelConsumptionPerKilometer = fuelConsumptionFor1km
                    };

                    cars.Add(currentCar);
                }
            }


            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] elements = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = elements[0];

                if (action == "Drive")
                {
                    string carModel = elements[1];
                    double amountOfKm = double.Parse(elements[2]);

                    foreach (var car in cars)
                    {
                        if (car.Model == carModel)
                        {
                            car.MoveToADistance(amountOfKm);
                        }
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}


