namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {

        private Book book;
        [SetUp]
        public void SetUp()
        {
            book = new Book("Avatar","Roberto");
        }
        [TearDown]
        public void TearDown()
        {
            book = null;
        }
        [Test]
        public void TestConstructor()
        {
            book = new Book("Avatar", "Roberto");
            Assert.AreEqual("Avatar", book.BookName);
            Assert.AreEqual("Roberto", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void TestBookNameShouldThrowIfItIsNullOrEmpty()
        {

            Assert.Throws<ArgumentException>(() => book = new Book("", "Roberto"));
        }
        [Test]
        public void TestBookAuthorShouldThrowIfItIsNullOrEmpty()
        {

            Assert.Throws<ArgumentException>(() => book = new Book("kriss", ""));
        }
        [Test]
        public void TestAddFootNoteIfExistWillThrow()
        {
            book.AddFootnote(1, "hi");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "hi"));
        }
        [Test]
        public void TestAddFootNotePositiveTest()
        {
            book.AddFootnote(1, "hi");
            Assert.AreEqual(book.FootnoteCount, 1); 
        }
        [Test]
        public void TestFootNoteFindIfDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));
        }
        [Test]
        public void TestFootNoteFindPositiveTest()
        {
            book.AddFootnote(1, "hi");
            var result  =book.FindFootnote(1);
            Assert.AreEqual(result.Length, 15);
        }
        [Test]
        public void TestAlterFootNoteSholdThrowIfDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, "kf"));
        }
        [Test]
        public void AlterMethodWillChangeTheTextCorrectly()
        {
            book.AddFootnote(1, "hi");
            book.AlterFootnote(1, "fkgfkg");
            var result = book.FindFootnote(1);
            Assert.AreNotEqual(result.Length, 15);
        }


    }
}