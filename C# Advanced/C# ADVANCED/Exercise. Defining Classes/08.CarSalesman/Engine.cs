using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            string model = $"  {Model}:";
            string power = $"    Power: {Power}";
            string displacement = string.Empty;
            string efficiency = string.Empty;

            if (Displacement != 0)
            {
                displacement = $"    Displacement: {Displacement}";
            }
            else
            {
                displacement = "    Displacement: n/a";
            }

            if (Efficiency != null)
            {
                efficiency = $"    Efficiency: {Efficiency}";
            }
            else
            {
                efficiency = "    Efficiency: n/a";
            }

            return $"{model}\n{power}\n{displacement}\n{efficiency}";
        }
    }
}
