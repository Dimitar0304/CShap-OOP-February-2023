namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person person;
        [SetUp]
        public void SetUp()
        {
            database = new Database();
            
        }
        [TearDown]
        public void TearDown()
        {
            database = null;
        }
        [Test]
        public void AddMethodTest()
        {
            database.Add(new Person(3,"Gosho"));

            Person result = database.FindById(3);

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(3,result.Id);
            Assert.AreEqual("Gosho", result.UserName);



        }
        [Test]
        public void AddMethodShouldThrowIfAlreadyExistPersonWithThisUsername()
        {
            database.Add(person = new Person(1, "Mitko"));

            Assert.Throws<InvalidOperationException>(() => database.Add(person = new Person(2, "Mitko")));
        }
        [Test]
        public void AddMethodShouldThrowIfAlreadyExistPersonWithThisId()
        {
            database.Add(person = new Person(1, "Mitko"));

            Assert.Throws<InvalidOperationException>(() => database.Add(person = new Person(1, "Goshho")));
        }
        [Test]
        public void AddMethodShouldThrowIfCapacityIsEqualTo16()
        {
            AddToArray();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(19, "mitkaa")));
        }
        public void AddToArray()
        {
            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"{i}");
                database.Add(person);
            }
        }
        [Test]
        public void RemoveMethodShouldThrowWhenItIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());

            
        }
        [Test]
        public void RemoveMethodCount()
        {
            database = new Database(new Person(1, "Mitko"));
            database.Remove();
            Assert.AreEqual(0, database.Count,"Remove method doesn't remove ");
        }
        [Test]
        [TestCase  (null)]
        [TestCase("")]
        public void FindByUsrnameShouldThrowIfValueIsNullOrEmpty( string model)
        {
           ArgumentNullException exeption = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(model));
         

        }
        [Test]
        public void FindByUsernameShouldThrowIfValueDoNotExist()
        {
            database.Add(person = new Person(1, "Mitko"));
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Kalcho"));
            Assert.AreEqual(exception.Message, "No user is present by this username!");
        }
        [Test]
        public void FindByUsernameShouldReturnTheNameWichWeSearch()
        {
            database.Add(person = new Person(1, "Mitko"));

            var findedPerson = database.FindByUsername("Mitko");
            Assert.AreEqual("Mitko", findedPerson.UserName);
        }
        [Test]
        public void FindByIdShouldThrowIfIdIsNegaticeNumber()
        {
            ArgumentOutOfRangeException exept = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
        [Test]
        public void FindByIdSholdThrowIfNotExist()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindById(1));
            Assert.AreEqual(exception.Message, "No user is present by this ID!");

        }
        [Test]
        public void FindByIdShouldReturnIdWhenExist()
        {
            database.Add(person = new Person(1, "Mitko"));

            var findedPerson = database.FindById(1);

            Assert.AreEqual(1, findedPerson.Id);
        }
    }
}