namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();    
        }
        [TearDown] public void TearDown()
        {
            arena = null;
        }
        [Test]
        public void CreateArena()
        {
            arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }
        [Test]
        public void ArenaShouldThrowIfPlayerIsEnrolledAlready()
        {
            arena.Enroll(warrior = new Warrior("Mitko", 15, 100));


            var exepetion = Assert.Throws<InvalidOperationException>(()
                =>arena.Enroll(warrior=new Warrior("Mitko",15,100)));

            Assert.AreEqual(exepetion.Message, "Warrior is already enrolled for the fights!");

        }
        [Test]
        public void EnrollShouldEnrollNewPlayer()
        {
            arena.Enroll(warrior = new Warrior("Mitko",15,100));
            Assert.AreEqual(arena.Count, 1);
        }
        [Test]
        public void FightMethodThrowIfAttackerIsNull()
        {
            arena.Enroll(warrior = new Warrior("Mitko", 15, 100));

           var ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Kaloyan", "Mitko"));
            Assert.AreEqual(ex.Message, "There is no fighter with name Kaloyan enrolled for the fights!");
        }
        [Test]
        public void FightMethodThrowIfDeffenderIsNull()
        {
            arena.Enroll(warrior = new Warrior("Mitko", 15, 100));

            var ex = Assert.Throws<InvalidOperationException>(() => arena.Fight("Mitko", "Kaloyan"));
            Assert.AreEqual(ex.Message, "There is no fighter with name Kaloyan enrolled for the fights!");
        }
        [Test]
        public void TestFightAlready()
        {
            var attacker = new Warrior("Pesho", 15, 35);
            var defender = new Warrior("Gosho", 15, 45);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(20, attacker.HP);
            Assert.AreEqual(30, defender.HP);
        }
    }
}
