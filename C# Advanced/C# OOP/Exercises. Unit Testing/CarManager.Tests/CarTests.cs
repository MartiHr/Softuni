using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        CarManager.Car car;

        [SetUp]
        public void Setup()
        {
            car = new CarManager.Car("VW", "Golf", 8.0, 200.0);
        }

        [Test]
        [TestCase("", "Golf", 8.0, 200.0)]
        [TestCase(null, "Golf", 8.0, 200.0)]
        [TestCase("VW", "", 8.0, 200.0)]
        [TestCase("VW", null, 8.0, 200.0)]
        [TestCase("VW", "Golf", -5, 200.0)]
        [TestCase("VW", "Golf", 0.0, 200.0)]
        [TestCase("VW", "Golf", 8.0, -100)]
        [TestCase("VW", "Golf", 8.0, 0)]
        public void Ctor_ImproperIntialization(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new CarManager.Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_ProperIntialization()
        {
            Assert.AreEqual(car.Make, "VW");
            Assert.AreEqual(car.Model, "Golf");
            Assert.AreEqual(car.FuelConsumption, 8.00);
            Assert.AreEqual(car.FuelCapacity, 200);
            Assert.AreEqual(car.FuelAmount, 0);
        }
        
        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void Refuel_ZeroOrNegativeAmount(double condition)
        {
            Assert.That(() => car.Refuel(condition), Throws.ArgumentException);
        }

        [Test]
        public void Refuel_PositiveAmountBiggerThanCapacity()
        {
            double amount = 300;
            car.Refuel(amount);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        [Test]
        public void Refuel_PositiveAmountLessThanCapacity()
        {
            double amount = 199;
            car.Refuel(amount);
            Assert.AreEqual(car.FuelAmount, amount);
        }

        [Test]
        public void Drive_NotEnoughFuel()
        {
            Assert.That(() => car.Drive(5), Throws.InvalidOperationException);
        }

        [Test]
        public void Drive_EnoughFuel()
        {
            car.Refuel(100);
            car.Drive(5);
            Assert.That(car.FuelAmount, Is.LessThan(100));
        }
    }
}