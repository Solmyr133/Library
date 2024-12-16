using library.Models;
using Lorincz_Lorand_backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lorincz_Lorand_backend.Repositories.Services
{
    public class CategoryService : ICategoryInterface
    {
        private readonly LibrarydbContext _context;

        public CategoryService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetCategories()
        {
            var categories = await _context.Categories.Include(x => x.Books).ToListAsync();

            return categories;
        }
    }
}
