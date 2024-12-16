using library.Models;
using Lorincz_Lorand_backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static Lorincz_Lorand_backend.Models.DTOs;

namespace Lorincz_Lorand_backend.Repositories.Services
{
    public class BookService : IBookInterface
    {
        private readonly LibrarydbContext _context;

        public BookService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Book>> GetAllBook()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> Post(string uid, CreateNewBook createNewBook)
        {
            if (uid != "FKB3F4FEA09CE43C")
            {
                throw new UnauthorizedAccessException();
            }

            try
            {
                var currentBook = new Book
                {
                    Title = createNewBook.title,
                    AuthorId = createNewBook.authorId,
                    CategoryId = createNewBook.categoryId,
                    PublishDate = createNewBook.publishDate
                };

                await _context.Books.AddAsync(currentBook);
                await _context.SaveChangesAsync();

                return currentBook;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating book", ex);
            }
        }
    }
}
