using NUnit.Framework;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        private FootballTeam footballTeam;
        [SetUp]
        public void Setup()
        {
            footballTeam = new FootballTeam("Real", 22);
        }

        [TearDown]
        public void Test1()
        {
            footballTeam = null;
        }
        [Test]
        public void TestConstructor()
        {
            footballTeam = new FootballTeam("Real", 22);
            Assert.AreEqual("Real", footballTeam.Name);
            Assert.AreEqual(22, footballTeam.Capacity);
            Assert.AreEqual(0,footballTeam.Players.Count);
        }
    }
}