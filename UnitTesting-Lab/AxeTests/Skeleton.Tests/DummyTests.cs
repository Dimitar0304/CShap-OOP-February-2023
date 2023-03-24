using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLooseHelthWhenAttacked()
        {
            
            Dummy dummy = new Dummy(10, 10);

            
            dummy.TakeAttack(1);

            Assert.AreEqual(dummy.Health, 9, "When Dummy is attacked doesn't substract health");
        }
        [Test]
        public void DeadDummyThrowAnExeptionWhenAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
            
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1)
            ,"Dummy doen't throw exeption when it is attacked and it's dead");
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            dummy.GiveExperience();
            
            Assert.AreEqual(dummy.Health, 0, "Dummy can not give expirience when is dead");
        }
        [Test]
        public void AliveDummyCanNotGiveXP()
        {
            Dummy dummy = new Dummy(1, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),"Alive Dummy can give expirience");

           
        }


    }
}