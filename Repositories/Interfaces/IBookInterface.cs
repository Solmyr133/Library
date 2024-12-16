using library.Models;
using static Lorincz_Lorand_backend.Models.DTOs;

namespace Lorincz_Lorand_backend.Repositories.Interfaces
{
    public interface IBookInterface
    {
        Task<ICollection<Book>> GetAllBook();
        Task<Book> Post(string uid, CreateNewBook createNewBook);
    }
}
