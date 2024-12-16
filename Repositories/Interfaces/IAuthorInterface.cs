using library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lorincz_Lorand_backend.Repositories.Interfaces
{
    public interface IAuthorInterface
    {
        Task<Author> GetByName(string name);
        Task<int> GetCount();
    }
}
