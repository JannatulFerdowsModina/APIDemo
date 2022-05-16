using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Service.BookService
{
    public class BookInterface : IBookInterface
    {
        private readonly ApplicationDbContext _db;
        public BookInterface(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public string DeleteBook(int id)
        {
            var data = _db.Books.Find(id);

            if (data == null)
            {
                return "No data exsit with id " + id;
            }
            if (data != null)
            {
                _db.Books.Remove(data);
                _db.SaveChanges();
            }
            return "Succesfully Deleted";
        }

        public IEnumerable<Book> GetBooks()
        {
            var data = _db.Books.ToList();
            return data;
        }

        public string PostBook(Book book)
        {
            try
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return "Saved successfully";
            }
            catch (Exception e)
            {

                return "Exception occured" + e.Message;
            }


        }

        public string UpdateBook(int id, Book book)
        {
            
            try
            {
                var data = _db.Books.Find(id);
                if (data == null)
                {
                    return "No data exsit with id " + id;
                }
                if (data != null)
                {
                    data.Author = book.Author;
                    data.ISBN = book.ISBN;
                    data.Publisher = book.Publisher;
                    data.Title = book.Title;
                    _db.SaveChanges();
                    return "Saved successfully";
                }
                return "";
               
            }
            catch (Exception e)
            {

                return "Exception occured" + e.Message;
            }


        }
    }
}
