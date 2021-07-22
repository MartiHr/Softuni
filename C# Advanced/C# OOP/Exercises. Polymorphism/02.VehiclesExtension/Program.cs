using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new  Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

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
                                car.Drive(distance);
                                break;
                            case "Truck":
                                truck.Drive(distance);
                                break;
                            case "Bus":
                                bus.Drive(distance);
                                break;
                        }
                        break;
                    
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(commandElements[2]));
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
                            case "Bus":
                                bus.Refuel(fuelLiters);
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
