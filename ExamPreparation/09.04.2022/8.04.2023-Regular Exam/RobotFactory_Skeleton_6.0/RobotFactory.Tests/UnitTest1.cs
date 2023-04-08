using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        [SetUp]
        public void Setup()
        {
            factory = new Factory("H1", 100);
        }

        [TearDown]
        public void TearDown()
        {
            factory = null;
        }
        [Test]
        public void TestConstructor()
        {
            factory = new Factory("H1", 100);
            Assert.AreEqual(factory.Name, "H1");
            Assert.AreEqual(factory.Capacity, 100);
            Assert.AreEqual(factory.Supplements.Count, 0);
            Assert.AreEqual(factory.Robots.Count, 0);
        }
        [Test]
        public void TestProduceRobotMethodWillThrowIfNoCapacity()
        {
            factory = new Factory("H1", 1);
            Robot robot = new Robot("B3", 12, 23);
            factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);
            var result = factory.ProduceRobot("44", 99, 100);
            Assert.AreEqual(result, "The factory is unable to produce more robots for this production day!");

        }
        [Test]
        public void TestProduceRobotMethodIfHasCapacity()
        {
            factory = new Factory("H1", 100);
            Robot robot = new Robot("44", 99, 100);
            var result = factory.ProduceRobot("44", 99, 100);
            Assert.AreEqual(result, $"Produced --> {robot}");
            Assert.AreEqual(factory.Robots.Count, 1);

        }
        [Test]
        public void TestProduceSuplement()
        {
            Supplement supplement = new Supplement("Mig", 69);
           var result =  factory.ProduceSupplement("Mig", 69);
            Assert.AreEqual(result.ToString(), supplement.ToString());
            Assert.AreEqual(factory.Supplements.Count, 1);
        }
        [Test]
        public void TestUpgradeRobotTest()
        {
            Supplement supplement = new Supplement("Mig", 69);
            Robot robot = new Robot("44", 99,69);
            robot.Supplements.Add(supplement);
          bool result =  factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(result, false);
            Assert.AreEqual(supplement.InterfaceStandard, robot.InterfaceStandard);
            Assert.AreEqual(robot.Supplements.Contains(supplement),true);
        }
        [Test]
        public void TestUpgradeMethodIfAddSuplementToCurrentRobot()
        {
            Supplement supplement = new Supplement("Mig", 69);
            Robot robot = new Robot("44", 99, 69);
            bool result = factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(result, true);
            Assert.AreEqual(robot.Supplements.Count,1);
            Assert.AreEqual(supplement.Name, "Mig");
        }
        [Test]
        public void TestSellRobotMethod()
        {
            factory.ProduceRobot("h20", 80, 78);
            factory.ProduceRobot("K200", 400, 99);

            Robot robot = new Robot("K200", 400, 99);

            var result = factory.SellRobot(400);
            Assert.AreEqual(result.Price, robot.Price);
            Assert.AreEqual(result.Model, robot.Model);
            Assert.AreEqual(result.Supplements.Count, robot.Supplements.Count);
            Assert.AreEqual(result.InterfaceStandard, robot.InterfaceStandard);
            Assert.AreEqual(result.ToString(), robot.ToString());
           
           
        }
        [Test]
        public void TestIfSellMEthodReturnsNull()
        {
            var result = factory.SellRobot(400);
            Assert.AreEqual(result, null);
        }

    }


}
