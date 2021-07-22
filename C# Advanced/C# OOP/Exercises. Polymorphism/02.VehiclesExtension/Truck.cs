using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (TankCapacity >= FuelQuantity + liters * 0.95)
            {
                FuelQuantity += liters * 0.95;
            }
            else
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
        }
    }
}
