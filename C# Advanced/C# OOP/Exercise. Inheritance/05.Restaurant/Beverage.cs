namespace Restaurant
{
    public class Beverage : Product
    {
        public double Milliliters { get; set; }

        public new double Price { get; set; }

        public Beverage(string name, decimal price, double milliliters) 
            : base(name, price)
        {
            Milliliters = milliliters;
            Price = (double)price;
        }
    }
}
