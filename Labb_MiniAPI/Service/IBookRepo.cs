using ModelsLib.Models;

namespace Labb_MiniAPI.Service
{
    public interface IBookRepo
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book createBook);
        Task<Book> UpdateBook(Book updateBook, int id);
        Task<Book> DeleteBook(int id);
        Task<IEnumerable<Book>> Search(string search);
    }
}
