using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Repositories;

namespace WebApplication11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookController : ControllerBase
    {
        private readonly Repository _context;
        public bookController(Repository context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAllBooks()
        {
            var books = _context.books.ToList();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult getOneBook(int id)
        {
            try
            {
                var book = _context.books.Where(b => b.bookId.Equals(id)).SingleOrDefault();
                if (book is null)
                {
                    return NotFound(); //404
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult createOneBook([FromBody] book book) //paramtere olarak bir kitap nesnesi aldın
        {
            try //dene
            {
                if (book is null)
                {
                    return BadRequest(); //400
                }
                _context.books.Add(book);
                _context.SaveChanges();
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult updateOneBook([FromRoute] int id, [FromBody] book book)
        {
            try
            {
                var entity = _context.books.Where(b => b.bookId.Equals(id)).SingleOrDefault();
                if (entity is null)
                {
                    return NotFound(); //404
                }

                //check id
                if (id != book.bookId)
                {
                    return BadRequest(); //400
                }
                entity.price = book.price;
                //   entity.bookId = book.bookId;
                entity.name = book.name;
                _context.SaveChanges();
                return Ok(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult deleteOneBook([FromRoute(Name = "id")]int id)
        {
            try
            {
                var entity = _context.books.Where(b => b.bookId.Equals(id)).SingleOrDefault();
                if(entity is null)
                {
                    return NotFound();
                }
                _context.books.Remove(entity);
                _context.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        
    }
}
