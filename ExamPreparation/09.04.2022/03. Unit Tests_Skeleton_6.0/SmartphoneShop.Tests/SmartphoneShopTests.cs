using NUnit.Framework;
using System;
using System.Numerics;
using System.Reflection;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop smartphoneShop;
        [SetUp]
        public void SetUp()
        {
             smartphoneShop = new Shop(100);
        }
        [TearDown]
        public void TearDown()
        {
            smartphoneShop = null;
        }
        [Test]
        public void InitialiseTheShop()
        {
            smartphoneShop = new Shop(10);

            Assert.AreEqual(smartphoneShop.Capacity, 10);
            Assert.AreEqual(smartphoneShop.Count, 0);

        }
        [Test]
        public void InitialiseTheShopWithNegativeCapacityWillThrow()
        {
          var ex =  Assert.Throws<ArgumentException>(() => smartphoneShop = new Shop(-10));
            Assert.AreEqual(ex.Message, "Invalid capacity.");
        }
        [Test]
        public void AddMethodWillThrowIfSmarthphoneExist()
        {
            var smartphone = new Smartphone("Iphone", 100);
            smartphoneShop.Add(smartphone);

          var ex=  Assert.Throws<InvalidOperationException>(() => smartphoneShop.Add(smartphone));
            Assert.AreEqual(ex.Message, $"The phone model {smartphone.ModelName} already exist.");
        }
        [Test]
        public void AddMethodWillThrowIfTryToAddWhenNoCapacity()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            smartphoneShop.Add(smartphone);
            smartphone = new Smartphone("Samsung", 99);

            var ex = Assert.Throws<InvalidOperationException>(() => smartphoneShop.Add(smartphone));
            Assert.AreEqual(ex.Message, $"The shop is full.");
        }
        [Test]
        public void AddMethodPositiveCaseWillAddToCount()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            smartphoneShop.Add(smartphone);

            Assert.AreEqual(1, smartphoneShop.Count);
        }
        [Test]
        public void RemoveMethodWillThrowWhenPhoneNoExist()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            var ex = Assert.Throws<InvalidOperationException>(() => smartphoneShop.Remove(smartphone.ModelName));
            Assert.AreEqual(ex.Message, $"The phone model {smartphone.ModelName} doesn't exist.");
        }
        [Test]
        public void RemoveMethodWillRemovePositiveCase()
        {
            smartphoneShop = new Shop(10);
            var smartphone = new Smartphone("Iphone", 100);
            smartphoneShop.Add(smartphone);
            smartphoneShop.Remove(smartphone.ModelName);
            Assert.AreEqual(0,smartphoneShop.Count);
        }
        [Test]
        public void TestPhoneMethodIfPhoneToTestDoesNotExist()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            var ex = Assert.Throws<InvalidOperationException>(() => smartphoneShop.TestPhone(smartphone.ModelName,smartphone.CurrentBateryCharge));
            Assert.AreEqual(ex.Message, $"The phone model {smartphone.ModelName} doesn't exist.");
        }
        [Test]
        public void TestPhoneWithLowerCurrentBatteryThanBatteryUsage()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            smartphoneShop.Add(smartphone);
            var ex = Assert.Throws<InvalidOperationException>(() => smartphoneShop.TestPhone(smartphone.ModelName, 101));
            Assert.AreEqual(ex.Message, $"The phone model {smartphone.ModelName} is low on batery.");
        }
        [Test]
        public void TestPhonePositiveCase()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            smartphoneShop.Add(smartphone);
            smartphoneShop.TestPhone(smartphone.ModelName, 99);
            Assert.AreEqual(1, smartphone.CurrentBateryCharge);
        }
        [Test]
        public void ChargeMethodIfDoesNotFoundTheModelWillThrow()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            var ex = Assert.Throws<InvalidOperationException>(() => smartphoneShop.ChargePhone(smartphone.ModelName));
            Assert.AreEqual(ex.Message, $"The phone model {smartphone.ModelName} doesn't exist.");
        }
        [Test]
        public void PositiveCaseIfPhoneIsRecharged()
        {
            smartphoneShop = new Shop(1);
            var smartphone = new Smartphone("Iphone", 100);
            smartphoneShop.Add(smartphone);
            smartphoneShop.TestPhone(smartphone.ModelName, 99);
            smartphoneShop.ChargePhone(smartphone.ModelName);
            Assert.AreEqual(smartphone.CurrentBateryCharge, smartphone.MaximumBatteryCharge);
        }

    }
}