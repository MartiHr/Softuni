using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            Queue<string> carQueue = new Queue<string>();

            int counter = 0;

            while (command != "END")
            {
                if (command == "green")
                {
                    int currentGreenLight = greenLightDuration;
                    int currentFreeWindow = freeWindowDuration;

                    while (currentGreenLight > 0 && carQueue.Count > 0)
                    {
                        string currentCar = carQueue.Dequeue();

                        int carLength = currentCar.Length;
                        counter++;

                        if (carLength <= currentGreenLight)
                        {
                            currentGreenLight -= carLength;
                        }
                        else if (carLength > currentGreenLight && carLength <= currentGreenLight + currentFreeWindow)
                        {
                            break;
                        }
                        else
                        {
                            carLength -= currentGreenLight + currentFreeWindow;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[carLength]}.");
                            return;
                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
