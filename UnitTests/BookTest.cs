using Cqrs.Hosts;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Service.BookService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTests
{
    [TestFixture]
    public class BookTest
    {
        private  IBookInterface _bookInterface;
        private  ApplicationDbContext db;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
             //Using connectionString
            .UseSqlServer(@"Server=BS-769;Database=APIDemo;Trusted_Connection=True;MultipleActiveResultSets=True;")
            .Options;
            db = new ApplicationDbContext(contextOptions);
            _bookInterface = new BookInterface(db);
        } 
        [Test]
        public void test()
        {
            Assert.That(1, Is.Positive);
        }
        [Test]
        public void TestPostBookMethod()
        {
            Book book = new Book()
            {
                ISBN = 11111111,
                Title ="testTitle",
                Publisher="testPublisher",
                Author="testAuthor"
            };
           
           var a=_bookInterface.PostBook(book);
            Assert.That("Saved successfully", Is.EqualTo(a));
        }
        [Test]
        public void TestDeleteBookMethod()
        {
            

            var a = _bookInterface.DeleteBook(2);
            Assert.That(a, Is.EqualTo("No data exsit with id " + 2).Or.EqualTo("Succesfully Deleted"));
        }
        [Test]
        public void TestBookUpdateMethod()
        {
            Book book = new Book()
            {
                ISBN = 11111111,
                Title = "testTitle",
                Publisher = "testPublisher",
                Author = "testAuthor"
            };

            var a = _bookInterface.UpdateBook(3,book);
            Assert.That(a, Is.EqualTo("No data exsit with id " + 3).Or.EqualTo("Saved successfully"));

        }

    }
}
