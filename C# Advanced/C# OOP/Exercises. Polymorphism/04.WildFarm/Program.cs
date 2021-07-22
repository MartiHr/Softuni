using _04.WildFarm.Animals;
using _04.WildFarm.Factories;
using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            string command2 = string.Empty;

            List<Animal> animals = new List<Animal>();

            while ((command = Console.ReadLine()) != "End" && (command2 = Console.ReadLine()) != "End")
            {
                string[] animalElements = command
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                Animal currentAnimal = AnimalFactory.Create(animalElements);
                animals.Add(currentAnimal);

                string[] foodElements = command2
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                Food currentFood = FoodFactory.Create(foodElements);

                Console.WriteLine(currentAnimal.ProduceSound());

                try
                {
                    currentAnimal.Feed(currentFood);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
