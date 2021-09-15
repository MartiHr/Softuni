namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private RobotManager robotManager;

        [SetUp]
        public void Setup()
        {
            robotManager = new RobotManager(5);
        }

        [Test]
        public void Ctor_Init()
        {
            Assert.AreEqual(5, robotManager.Capacity);
            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void Capacity()
        {
            Assert.AreEqual(5, robotManager.Capacity);
        }

        [Test]
        public void Capacity_Exception()
        {
            Assert.That(() => new RobotManager(-5), Throws.ArgumentException);
        }

        [Test]
        public void Add()
        {
            robotManager.Add(new Robot("Gosho", 50));

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void Add_AlreadyExists()
        {
            Robot robot = new Robot("Gosho", 50);
            robotManager.Add(robot);
            Assert.That(() => robotManager.Add(robot), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_NotEnoughCapacity()
        {
            robotManager = new RobotManager(1);
            robotManager.Add(new Robot("Gosho", 5));

            Assert.That(() => robotManager.Add(new Robot("Pesho", 6)), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove()
        {
            Robot robot = new Robot("Gosho", 50);
            robotManager.Add(robot);
            robotManager.Remove("Gosho");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void Remove_Exception()
        {
            Assert.That(() => robotManager.Remove("Gosho"), Throws.InvalidOperationException);
        }

        [Test]
        public void Work_Null()
        {
            Assert.That(() => robotManager.Work("Gosho", "IT", 10), Throws.InvalidOperationException);
        }

        [Test]
        public void Work_NotEnoughBattery()
        {
            Robot robot = new Robot("Gosho", 20);
            robotManager.Add(robot);
            Assert.That(() => robotManager.Work("Gosho", "IT", 50), Throws.InvalidOperationException);
        }

        [Test]
        public void Work()
        {
            Robot robot = new Robot("Gosho", 100);
            robotManager.Add(robot);
            robotManager.Work("Gosho", "IT", 25);

            Assert.AreEqual(75, robot.Battery);
        }

        [Test]
        public void Charge_Null()
        {
            Assert.That(() => robotManager.Charge("Gosho"), Throws.InvalidOperationException);
        }

        [Test]
        public void Charge()
        {
            Robot robot = new Robot("Gosho", 50);
            robotManager.Add(robot);
            robotManager.Work("Gosho", "IT", 25);
            robotManager.Charge("Gosho");

            Assert.AreEqual(50, robot.Battery);
        }
    }
}
