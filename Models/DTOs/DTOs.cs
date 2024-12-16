namespace Lorincz_Lorand_backend.Models
{
    public class DTOs
    {
        public record CreateNewBook(string title, DateTime publishDate, int authorId, int categoryId);
    }
}
