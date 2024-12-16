using library.Models;
using Lorincz_Lorand_backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lorincz_Lorand_backend.Repositories.Services
{
    public class AuthorService : IAuthorInterface
    {
        private readonly LibrarydbContext _context;
        public AuthorService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<Author> GetByName(string name)
        {
            var selectedAuthor = await _context.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.AuthorName == name);

            return selectedAuthor;
        }

        public async Task<int> GetCount()
        {
            return await _context.Authors.CountAsync();
        }
    }
}
