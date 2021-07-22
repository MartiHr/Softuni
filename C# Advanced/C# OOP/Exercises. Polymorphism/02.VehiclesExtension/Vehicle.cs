using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get => tankCapacity;
            set
            {
                if (FuelQuantity > value)
                {
                    FuelQuantity = 0;
                }

                tankCapacity = value;
            }
        }

        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }

        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set
            {
                fuelConsumption = value;
            }
        }

        public void Drive(double distance)
        {
            if (CanDrive(distance))
            {
                FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public void Drive(double distance, double fuelConsumption)
        {
            if (CanDrive(distance, fuelConsumption))
            {
                FuelQuantity -= distance * fuelConsumption;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        protected bool CanDrive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                return true;
            }

            return false;
        }

        protected bool CanDrive(double distance, double fuelConsumption)
        {
            if (FuelQuantity >= fuelConsumption * distance)
            {
                return true;
            }

            return false;
        }


        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (TankCapacity > FuelQuantity + liters)
            {
                FuelQuantity += liters;
            }
            else
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
