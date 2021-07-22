using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
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

        public bool CanDrive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                return true;
            }

            return false;
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
