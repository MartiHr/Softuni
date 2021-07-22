using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value + 1.4; }

        public void DriveEmpty(double distance)
        {
            Drive(distance, FuelConsumption - 1.4);
        }
    }
}
