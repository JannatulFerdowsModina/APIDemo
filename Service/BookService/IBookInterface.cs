using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BookService
{
    public interface IBookInterface
    {
        IEnumerable<Book> GetBooks();
        string PostBook(Book book);
        string UpdateBook(int id, Book book);
        string DeleteBook(int id);
    }
}
