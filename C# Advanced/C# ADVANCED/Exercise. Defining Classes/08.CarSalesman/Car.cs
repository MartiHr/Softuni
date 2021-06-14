using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; } 

        public string Color { get; set; }

        public override string ToString()
        {
            string model = $"{Model}:";
            string engine = Engine.ToString();
            string weight;
            string color;

            if (Weight != 0)
            {
                weight = $"  Weight: {Weight}";
            }
            else
            {
                weight = $"  Weight: n/a";
            }

            if (Color != null)
            {
                color = $"  Color: {Color}";
            }
            else
            {
                color = $"  Color: n/a";
            }

            return $"{model}\n{engine}\n{weight}\n{color}";
        }
    }
}
