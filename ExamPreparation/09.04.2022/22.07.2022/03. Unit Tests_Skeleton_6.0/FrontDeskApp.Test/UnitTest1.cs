using FrontDeskApp;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Trimontiom", 5);
        }

        [TearDown]
        public void TearDown()
        {
            hotel = null;
        }
        [Test]
        public void TestConstructor()
        {
            hotel = new Hotel("Trimontiom", 5);
            Assert.AreEqual(hotel.FullName, "Trimontiom");
            Assert.AreEqual(hotel.Category, 5);
            Assert.AreEqual(hotel.Bookings.Count, 0);
            Assert.AreEqual(hotel.Rooms.Count, 0);
        }
        [Test]
        [TestCase(" ")]
        [TestCase(null)]
        public void IfFullNameIsNullOrWhiteSpaceWillTrow(string model)
        {

            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(model, 5));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(6)]
        public void IfFullCategoryIsLessThen1OrMoreThanFiveWillTrow(int category)
        {

            Assert.Throws<ArgumentException>(() => hotel = new Hotel("Trimonitom", category));
        }
        [Test]
        public void TestBookRoomMethodWithoutAdults()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 4, 300));
        }
        [Test]
        public void TestBookRoomMethodWithNegativeChildren()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -2, 4, 300));
        }
        [Test]
        public void TestBookRoomMethodIfDurationIsLessThanOneDay()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 2, 0, 300));
        }
        [Test]
        public void TestBookRoomIfAllIsSuccses()
        {
            Room room = new Room(4, 30);


            hotel.AddRoom(room);
            hotel.BookRoom(1, 2, 3, 30000);
            Assert.AreEqual(hotel.Bookings.Count, 1);
            Assert.AreNotEqual(hotel.Turnover, 0);
        }
        [Test]
        public void TestAddRoomMethod()
        {
            Room room = new Room(4, 30);


            hotel.AddRoom(room);
            Assert.AreEqual(hotel.Rooms.Count,1);
        }
    }
}