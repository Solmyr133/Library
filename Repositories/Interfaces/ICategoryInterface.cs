using Microsoft.AspNetCore.Mvc;
using library.Models;

namespace Lorincz_Lorand_backend.Repositories.Interfaces
{
    public interface ICategoryInterface
    {
        Task<ICollection<Category>> GetCategories();
    }
}
