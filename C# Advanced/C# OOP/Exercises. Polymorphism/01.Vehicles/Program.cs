using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ");
            string[] truckInfo = Console.ReadLine()
                .Split(" ");

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandElements = Console.ReadLine()
                    .Split(" ");
                
                switch (commandElements[0])
                {
                    case "Drive":
                        double distance = double.Parse(commandElements[2]);

                        switch (commandElements[1])
                        {
                            case "Car":
                                if (car.CanDrive(distance))
                                {
                                    car.FuelQuantity -= distance * car.FuelConsumption;
                                    Console.WriteLine($"Car travelled {distance} km");
                                }
                                else
                                {
                                    Console.WriteLine("Car needs refueling");
                                }
                                break;
                            case "Truck":
                                if (truck.CanDrive(distance))
                                {
                                    truck.FuelQuantity -= distance * truck.FuelConsumption;
                                    Console.WriteLine($"Truck travelled {distance} km");
                                }
                                else
                                {
                                    Console.WriteLine("Truck needs refueling");
                                }
                                break;
                        }
                        break;

                    case "Refuel":
                        double fuelLiters = double.Parse(commandElements[2]);

                        switch (commandElements[1])
                        {
                            case "Car":
                                car.Refuel(fuelLiters);
                                break;
                            case "Truck":
                                truck.Refuel(fuelLiters);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
