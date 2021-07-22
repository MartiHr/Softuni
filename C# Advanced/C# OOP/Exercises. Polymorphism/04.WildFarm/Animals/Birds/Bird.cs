namespace _04.WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; private set; }

        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
