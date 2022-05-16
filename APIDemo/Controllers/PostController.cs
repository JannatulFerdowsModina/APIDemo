using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {

            var data = _db.Posts.ToList();
            return Ok(data);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Post post)
        {
            
                    _db.Posts.Add(post);
                    _db.SaveChanges();                 
                    return Ok();        
        }
        [HttpPut]
        public ActionResult Update( [FromBody] Post post)
        {
            var data = _db.Posts.Find(post.Id);
            if(data!=null)
            {
                data.Title = post.Title;
                data.body = post.body;
                _db.SaveChanges();
            }
           
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var data = _db.Posts.Find(id);
            try
            {
                if(data==null)
                {
                    return NotFound("no data exsit with id " + id);
                }
                if (data != null)
                {
                    _db.Posts.Remove(data);
                    _db.SaveChanges();
                }
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

    }
}