using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApiCore1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApiCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookApiCoreDbContext db;
        public BooksController()
        {
            db = new BookApiCoreDbContext();
        }


        // GET api/values
        [HttpGet]
        public IActionResult GetBookList()
        {
            return Ok(db.Books.ToList());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            Books book = db.Books.Find(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post(Books newBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            db.Books.Add(newBook);
            db.SaveChanges();

            return Ok(db.Books.ToList());
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Books book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Books bookToUpdate = db.Books.Find(id);
            if(bookToUpdate == null)
            {
                return NotFound();
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Price = book.Price;
            db.SaveChanges();


            return Ok(db.Books.ToList());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Books bookToDelete = db.Books.Find(id);

            if(bookToDelete == null)
            {
                return NotFound();
            }

            db.Books.Remove(bookToDelete);
            db.SaveChanges();

            return Ok(db.Books.ToList());
        }
    }
}