using _04.WildFarm.Foods;

namespace _04.WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; set; }

        public double FoodEaten { get; set; }

        public abstract string ProduceSound();

        public abstract void Feed(Food food);
    }
}
