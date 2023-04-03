namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    
    public class Tests
    {
        private UniversityLibrary universityLibrary;
        [SetUp]
        public void Setup()
        {
            universityLibrary = new UniversityLibrary();
        }

        [TearDown]
        public void TearDown()
        {
            universityLibrary = null;
        }
        [Test]
        public void TestConstructor()
        {
            universityLibrary = new UniversityLibrary();
            Assert.AreEqual(0, universityLibrary.Catalogue.Count);
        }
        [Test]
        public void AddTextBookToLibrary()
        {
            TextBook textBook = new TextBook("Mirage", "GShopov", "Romace");
            universityLibrary.AddTextBookToLibrary(textBook);
            Assert.AreEqual(1, universityLibrary.Catalogue.Count);
        }
        [Test]
        public void TestAddTextBookToLibraryDoesReturnTrueString()
        {
            TextBook textBook = new TextBook("Mirage", "GShopov", "Romace");
          var result=  universityLibrary.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook.InventoryNumber, 1);
            Assert.AreEqual(result, textBook.ToString());
        }
        [Test]
        public void TestLoanTextBook()
        {

            TextBook textBook = new TextBook("Mirage", "GShopov", "Romace");
            textBook.Holder = "Mitko";
            textBook.InventoryNumber = 1;
            universityLibrary.AddTextBookToLibrary(textBook);
            var resullt = universityLibrary.LoanTextBook(1, "Mitko");
            Assert.AreEqual(textBook.Holder, "Mitko");
            Assert.AreEqual(resullt, $"Mitko still hasn't returned {textBook.Title}!");
        }
        [Test]
        public void TestLoanTextBookIfHolderDontExist()
        {
            TextBook textBook = new TextBook("Mirage", "GShopov", "Romace");
            textBook.InventoryNumber = 1;
            universityLibrary.AddTextBookToLibrary(textBook);
            var result = universityLibrary.LoanTextBook(1, "Mitko");
            Assert.AreEqual(textBook.Holder, "Mitko");
            Assert.AreEqual(result, $"{textBook.Title} loaned to Mitko.");
        }
        [Test]
        public void TestReturnTextBookMethod()
        {
            TextBook textBook = new TextBook("Mirage", "GShopov", "Romace");
            textBook.InventoryNumber = 1;
            universityLibrary.AddTextBookToLibrary(textBook);
            universityLibrary.LoanTextBook(1, "Mitko");
            var result = universityLibrary.ReturnTextBook(1);
            Assert.AreEqual(textBook.Holder, string.Empty);
            Assert.AreEqual(result, $"{textBook.Title} is returned to the library.");
        }
    }
}