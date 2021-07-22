using _04.WildFarm.Animals;
using _04.WildFarm.Animals.Birds;
using _04.WildFarm.Animals.Mammals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public class AnimalFactory
    {
        public static Animal Create(string[] elements)
        {
            string animalType = elements[0];

            switch (animalType)
            {
                case "Cat":
                    return new Cat(elements[1], double.Parse(elements[2]),elements[3], elements[4]);
                case "Tiger":
                    return new Tiger(elements[1], double.Parse(elements[2]),elements[3], elements[4]);
                case "Owl":
                    return new Owl(elements[1], double.Parse(elements[2]), double.Parse(elements[3]));
                case "Hen":
                    return new Hen(elements[1], double.Parse(elements[2]), double.Parse(elements[3]));
                case "Dog":
                    return new Dog(elements[1], double.Parse(elements[2]), elements[3]);
                case "Mouse":
                    return new Mouse(elements[1], double.Parse(elements[2]), elements[3]);
                default:
                    throw new ArgumentException("Wrong input");
            }
        }
    }
}
