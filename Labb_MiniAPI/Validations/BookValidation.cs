using FluentValidation;
using ModelsLib.Models;

namespace Labb_MiniAPI.Validations
{
    public class BookValidation : AbstractValidator<BookDTO>
    {
        public BookValidation() 
        {
            RuleFor(book => book.Title).NotEmpty();
            RuleFor(book => book.Author).NotEmpty();
            RuleFor(book => book.PublishingYear).InclusiveBetween(1, DateTime.Now.Year);
            RuleFor(book => book.Description).NotEmpty();
            RuleFor(book => book.Genre).NotEmpty();
        }
    }
}
