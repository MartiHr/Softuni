using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Engine> engineByModel = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = elements[0];
                int power = int.Parse(elements[1]);

                Engine currentEngine = new Engine
                {
                    Model = model,
                    Power = power
                };

                if (elements.Length >= 3)
                {
                    if (char.IsDigit(elements[2][0]) )
                    {
                        currentEngine.Displacement = int.Parse(elements[2]);
                    }
                    else
                    {
                        currentEngine.Efficiency = elements[2];
                    }
                }
                if (elements.Length == 4)
                {
                    if (char.IsDigit(elements[3][0]))
                    {
                        currentEngine.Displacement = int.Parse(elements[3]);
                    }
                    else
                    {
                        currentEngine.Efficiency = elements[3];
                    }
                }

                if (!engineByModel.ContainsKey(model))
                {
                    engineByModel.Add(model, currentEngine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = elements[0];
                Engine engineForTheCar = engineByModel[elements[1]];

                Car currentCar = new Car
                {
                    Model = model,
                    Engine = engineForTheCar
                };

                if (elements.Length >= 3)
                {
                    if (char.IsDigit(elements[2][0]))
                    {
                        currentCar.Weight = int.Parse(elements[2]);
                    }
                    else
                    {
                        currentCar.Color = elements[2];
                    }
                }
                if (elements.Length == 4)
                {
                    if (char.IsDigit(elements[3][0]))
                    {
                        currentCar.Weight = int.Parse(elements[3]);
                    }
                    else
                    {
                        currentCar.Color = elements[3];
                    }
                }

                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
