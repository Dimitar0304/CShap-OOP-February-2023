namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Arena arena;
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior = new Warrior("Mitko", 15, 30);
        }
        [TearDown]
        public void TearDown()
        {
            arena = null;
            warrior = null;
        }
        [Test]
        public void CreateWarrior()
        {
            warrior = new Warrior("Mitko", 15, 100);

            Assert.AreEqual("Mitko", warrior.Name);
            Assert.AreEqual(15, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }
        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void NameWillThrowIfItIsNullOrWhiteSpace(string name)
        {
            var ex = Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, 15, 100));
            Assert.AreEqual(ex.Message, "Name should not be empty or whitespace!");
        }
        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        public void DamageWillThrowIfItIsNullOrWhiteSpace(int dmg)
        {
            var ex = Assert.Throws<ArgumentException>(() => warrior = new Warrior("Mitko", dmg, 100));
            Assert.AreEqual(ex.Message, "Damage value should be positive!");
        }
        [Test]
        public void HpWillThrowIfIsNegativeNumber()
        {
            var ex = Assert.Throws<ArgumentException>(() => warrior = new Warrior("Mitko", 15, -4));
            Assert.AreEqual(ex.Message, "HP should not be negative!");
        }
        [Test]
        public void AttackMethodWillThrowIfAttackerHpIsLowerThan30()
        {
            Warrior war = new Warrior("Hari", 100, 300);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(war));
        }
        [Test]
        public void AttackMethodWillThrowIfAttackedHpIsLowerThan30()
        {
            Warrior war = new Warrior("Hari", 31, 100);

            Assert.Throws<InvalidOperationException>(() => war.Attack(warrior));
        }
        [Test]
        public void AttackWhenWarriorAttackedStrongerEnemyThanHisHp()
        {
            Warrior war = new Warrior("Hari", 100, 100);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(war));
        }
        [Test]
        public void AttackShouldSucceed()
        {
            var attacker = new Warrior("Mitko", 15, 45);
            var defender = new Warrior("Gosho", 15, 35);

            attacker.Attack(defender);

            Assert.AreEqual(30, attacker.HP);
            Assert.AreEqual(20, defender.HP);
        }

        [Test]
        public void AttackShouldKill()
        {
            var attacker = new Warrior("Pesho", 45, 35);
            var defender = new Warrior("Gosho", 15, 35);

            attacker.Attack(defender);

            Assert.AreEqual(20, attacker.HP);
            Assert.AreEqual(0, defender.HP);
        }
    }
}