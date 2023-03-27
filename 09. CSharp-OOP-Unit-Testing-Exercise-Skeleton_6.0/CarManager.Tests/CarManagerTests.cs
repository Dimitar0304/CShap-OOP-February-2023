namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Audi", "A3", 8, 50);
        }
        [TearDown]
        public void TearDown()
        {
            car = null;
        }
        [Test]
        public void TestConstructor()
        {
            car = new Car("Audi", "A3", 8, 50);

            Assert.AreEqual("Audi", car.Make);
            Assert.AreEqual("A3", car.Model);
            Assert.AreEqual(8, car.FuelConsumption);
            Assert.AreEqual(50, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakeShouldThrowIfIsNullOrEmpty(string make)
        {
            var exeption = Assert.Throws<ArgumentException>(() => car = new Car(make, "A3", 8, 50));
            Assert.AreEqual(exeption.Message, "Make cannot be null or empty!");

        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelShouldThrowIfIsNullOrEmpty(string model)
        {
            var exeption = Assert.Throws<ArgumentException>(() => car = new Car("Audi", model, 8, 50));
            Assert.AreEqual(exeption.Message, "Model cannot be null or empty!");
        }
        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void FuelCompsumptionShouldThrowIfIsNullOrNegative(double fuelcomsumption)
        {
            var exeption = Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", fuelcomsumption, 50));
            Assert.AreEqual(exeption.Message, "Fuel consumption cannot be zero or negative!");

        }
        [Test]
        [TestCase(-3)]
        [TestCase(0)]
        public void RefuelMethodWithNegativeNumbersShouldThrow(int fuelAmmount)
        {

            var exeption = Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmmount));
            Assert.AreEqual(exeption.Message, "Fuel amount cannot be zero or negative!");


        }
        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void FuelCapacityShouldThrowIfIsNullOrNegative(double fuelCapacity)
        {
          var exeption=Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", 8, fuelCapacity));
            Assert.AreEqual(exeption.Message, "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void FuelAmmountIsMoreThanFuelCapacity()
        {
            car.Refuel(60);
            Assert.AreEqual(50, car.FuelAmount);
        }
        [Test]
        public void RefuelShouldAddToFuelAmmount()
        {
            car.Refuel(30);
            Assert.AreEqual(30, car.FuelAmount);
        }
        [Test]
        public void DriveMethodWillThrowIfYouHaveNot≈noughFuel()
        {
            car.Refuel(10);
         var exeption= Assert.Throws<InvalidOperationException>(() => car.Drive(200));

            Assert.AreEqual(exeption.Message, "You don't have enough fuel to drive!");
        }
        [Test]
        public void DriveMethodWillSubstractFuelAmmount()
        {
            car.Refuel(9);
            car.Drive(100);
            Assert.AreEqual(1, car.FuelAmount);
        }


    }
}