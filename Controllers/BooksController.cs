using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookEndsAPI.Data;
using BookEndsAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEndsAPI.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase{
        private readonly AppDBContext _context;

        public BooksController(AppDBContext context){
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(){
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id){
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return book;
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.BookID }, book);
        }
            //in command prompt: curl -X POST "http://localhost:5001/api/Books" -H "Content-Type: application/json" -d "{\"title\":\"The Great Gatsby\",\"author\":\"F. Scott Fitzgerald\",\"genre\":\"Classic\",\"rating\":5,\"dateFinished\":\"2024-03-19T00:00:00\",\"notes\":\"Loved the symbolism!\"}"


        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookID) return BadRequest();
            
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}