namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

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
            database.Add(1);
            var result = database.Fetch();

            Assert.AreEqual(1, result[0],"Adding value to element does't work");
            Assert.AreEqual(1, database.Count,"Databbase count doesn't work");
        }

        [Test]
        public void ArrayNoFreeSpaceThrowExeption()
        {
            Database db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);



            Assert.Throws<InvalidOperationException>(() => db.Add(1), "Database capacity is not fixed to 16 elements");
        }
        [Test]
        public void Test_ForTryToRemoveEmptyDB()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove(), "Database can't Remove from empty Data");
        }
        [Test]
        public void TestRemoveMethod()
        {
            database = new Database(1, 2);

            database.Remove();
            var result = database.Fetch();

            Assert.AreEqual(1, database.Count,"Database count after remove doesn't work");
           



            
        }
            [Test]
        public void FetchMethodWillReturnStateOfDataIntArray()
        {
            Database db = new Database(1, 2, 3);

            var result = db.Fetch();



            Assert.That(new int[] { 1, 2, 3 }, Is.EquivalentTo(result),"Fetch method doesn't work");

        }
    }
}

