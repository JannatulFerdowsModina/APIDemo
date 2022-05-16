using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.BookService;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        public BooksController(IBookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var result = _bookInterface.GetBooks();
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            var result = _bookInterface.PostBook(book);
            return Ok(result);
        }
        [HttpPut]
        public ActionResult Update(int id,[FromBody] Book book)
        {
            var data = _bookInterface.UpdateBook(id, book);
            return Ok(data);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = _bookInterface.DeleteBook(id);
            
                return Ok(data);        
        }
        }
    }