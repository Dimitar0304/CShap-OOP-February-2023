using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeDurabilityLooseForEachAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10,10);

            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, 9, "Axe loose durabiity for each attack does't work");
        }
        [Test]
        public void Test_AttackWithBrokenWepon()
        {
            Axe axe = new Axe(10,0);
            Dummy dummy = new Dummy(10,10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),"Axe can attack without durability");

            
        }
    }
}