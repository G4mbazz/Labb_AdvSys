using Labb_MiniAPI.Data;
using Microsoft.EntityFrameworkCore;
using ModelsLib.Models;

namespace Labb_MiniAPI.Service
{
    public class BookRepo : IBookRepo
    {
        private readonly MiniApiDbContext _context;
        public BookRepo(MiniApiDbContext context)
        {
            _context = context;
        }
        public async Task<Book> CreateBook(Book createBook)
        {
            var found = await _context.Books.FirstOrDefaultAsync(x => x.Title == createBook.Title && x.Author == createBook.Author);
            if (found != null)
            {
                return null;
            }
            var result = await _context.Books.AddAsync(createBook);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.ID == id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var result = await _context.Books.ToListAsync();
            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<IEnumerable<Book>> Search(string search)
        {
            var result = await _context.Books.Where(s => s.Title.ToLower() == search 
            || s.Author.ToLower() == search 
            || s.Genre.ToLower() == search 
            || s.PublishingYear.ToString() == search).Distinct().ToListAsync();
            return result.Any() ? result : null;
        }

        public async Task<Book> UpdateBook(Book updateBook, int id)
        {
            var found = await _context.Books.FirstOrDefaultAsync(x => x.ID == id);
            if (found != null)
            {
                found.Title = updateBook.Title;
                found.Author = updateBook.Author;
                found.PublishingYear = updateBook.PublishingYear;
                found.Stock = updateBook.Stock;
                found.Description = updateBook.Description;
                found.Genre = updateBook.Genre;
                await _context.SaveChangesAsync();
            }
            return found;
        }
    }
}
