using library.Models;
using Lorincz_Lorand_backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Lorincz_Lorand_backend.Models.DTOs;

namespace Lorincz_Lorand_backend.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookInterface bookInterface;
        public BooksController(IBookInterface bookInterface)
        {
            this.bookInterface = bookInterface;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult<ICollection<Book>>> GetAllBook()
        {
            try
            {
                var books = await bookInterface.GetAllBook();

                if (books.Count == 0)
                {
                    return NotFound();
                }

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("{uid}")]
        public async Task<ActionResult<Book>> Post(string uid, CreateNewBook createNewBook)
        {
            try
            {
                var newBook = await bookInterface.Post(uid, createNewBook);

                return StatusCode(201, "Könyv hozzáadása sikeresen megtörtént");
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Nincs jogosultsága új könyv felvételéhez!");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
