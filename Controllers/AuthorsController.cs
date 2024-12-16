using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using library.Models;
using Lorincz_Lorand_backend.Repositories.Interfaces;

namespace Lorincz_Lorand_backend.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorInterface authorInterface;

        public AuthorsController(IAuthorInterface authorInterface)
        {
            this.authorInterface = authorInterface;
        }

        [HttpGet("feladat9/{name}")]
        public async Task<ActionResult<Author>> GetById(string name)
        {
            var author = await authorInterface.GetByName(name);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpGet("feladat12")]
        public async Task<ActionResult<int>> GetCount()
        {
            int count = await authorInterface.GetCount();

            return Ok($"Szerzők száma: {count}");
        }
    }
}
