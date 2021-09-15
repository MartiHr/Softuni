namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void Init()
        {
            aquarium = new Aquarium("Splash", 20);
        }
        [Test]
        public void CtorWorksCorrectly()
        {
            Assert.That(aquarium.Name, Is.EqualTo("Splash"));
            Assert.That(aquarium.Capacity, Is.EqualTo(20));
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }
        [Test]
        public void GetNameWorksCorrectly()
        {
            Assert.That(aquarium.Name, Is.EqualTo("Splash"));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void GetNameThrowsException(string name)
        {
            Assert.That(() => aquarium = new Aquarium(name, 2), Throws.ArgumentNullException);
        }
        [Test]
        public void CapacityWorkCorrectly()
        {
            Assert.That(aquarium.Capacity, Is.EqualTo(20));
        }
        [Test]
        public void CapacityyThrowsExceptionWhenNegative()
        {
            Assert.That(() => aquarium = new Aquarium("dad", -1), Throws.ArgumentException);
        }
        [Test]
        public void CountWorksCorrectly()
        {
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }
        [Test]
        public void AddfishWorksFine()
        {
            Fish fish = new Fish("Gosho");
            Fish fish1 = new Fish("Gasdosho");
            Fish fish2 = new Fish("Goshasdo");
            Fish fish3 = new Fish("Gaasosho");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            Assert.That(aquarium.Count, Is.EqualTo(4));
        }
        [Test]
        public void AddFishThrowsException()
        {
            aquarium = new Aquarium("asas", 3);
            Fish fish = new Fish("Gosho");
            Fish fish1 = new Fish("Gasdosho");
            Fish fish2 = new Fish("Goshasdo");
            Fish fish3 = new Fish("Gaasosho");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.That(() => aquarium.Add(fish3), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveFishWorksFine()
        {
            Fish fish = new Fish("Gosho");
            Fish fish1 = new Fish("Gasdosho");
            Fish fish2 = new Fish("Goshasdo");
            Fish fish3 = new Fish("Gaasosho");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.RemoveFish("Gosho");
            aquarium.RemoveFish("Goshasdo");
            Assert.That(aquarium.Count, Is.EqualTo(2));
        }
        [Test]
        public void RemoveFishThrowsException()
        {
            Fish fish = new Fish("Gosho");
            Fish fish1 = new Fish("Gasdosho");
            Fish fish2 = new Fish("Goshasdo");
            Fish fish3 = new Fish("Gaasosho");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            Assert.That(() => aquarium.RemoveFish("aanannana"), Throws.InvalidOperationException);
        }
        [Test]
        public void SellFishThrowsException()
        {
            Fish fish = new Fish("Gosho");
            Fish fish1 = new Fish("Gasdosho");
            Fish fish2 = new Fish("Goshasdo");
            Fish fish3 = new Fish("Gaasosho");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            Assert.That(() => aquarium.SellFish("aanannana"), Throws.InvalidOperationException);
        }
        [Test]
        public void SellFishWorksFine()
        {
            Fish fish = new Fish("Gosho");
            Fish fish1 = new Fish("Gasdosho");
            Fish fish2 = new Fish("Goshasdo");
            Fish fish3 = new Fish("Gaasosho");
            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            Fish requestedfish = aquarium.SellFish("Gosho");
            fish.Available = false;
            Assert.That(requestedfish, Is.EqualTo(fish));
        }
        [Test]
        public void ReportWorksFine() 
        {

            Fish fish = new Fish("Gosho");
            Fish fish1 = new Fish("Ancho");

            aquarium.Add(fish);
            aquarium.Add(fish1);
            string toExpect = "Fish available at Splash: Gosho, Ancho";
            string report = aquarium.Report();
            Assert.That(report, Is.EqualTo(toExpect));
        }
    }
}
