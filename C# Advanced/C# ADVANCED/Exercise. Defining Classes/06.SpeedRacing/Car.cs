using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; } = 0;


        public void MoveToADistance(double amountOfKilometers)
        {
            if (amountOfKilometers * FuelConsumptionPerKilometer <= FuelAmount)
            {
                FuelAmount -= amountOfKilometers * FuelConsumptionPerKilometer;
                TravelledDistance += amountOfKilometers;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
