using ModelsLib.Models;

namespace Labb_MVC.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookByID<T>(int id);
        Task<T> UpdateBookAsync<T>(BookDTO bookDTO, int id);
        Task<T> CreateBookAsync<T>(BookDTO bookDTO);
        Task<T> DeleteAsync<T>(int id);
        Task<T> SearchBookAsync<T>(string searchRequest);
    }
}
