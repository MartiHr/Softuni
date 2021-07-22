namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(5, 5);
            Motorcycle motorcycle = new Motorcycle(5, 5);
            SportCar sportCar = new SportCar(5, 5);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(5, 5);

            System.Console.WriteLine(car.FuelConsumption);
        }
    }
}
