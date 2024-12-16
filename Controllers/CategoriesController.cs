using library.Models;
using Lorincz_Lorand_backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lorincz_Lorand_backend.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryInterface categoryInterface;

        public CategoriesController(ICategoryInterface categoryInterface)
        {
            this.categoryInterface = categoryInterface;
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult<ICollection<Category>>> GetCategories()
        {
            try
            {
                var categories = await categoryInterface.GetCategories();

                if (categories.Count == 0)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
