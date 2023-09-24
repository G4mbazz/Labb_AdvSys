using Labb_MiniAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_MiniAPI.Data
{
    public class MiniApiDbContext : DbContext
    {
        public MiniApiDbContext(DbContextOptions<MiniApiDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(new Book()
            {
                ID = 1,
                Author = "George B",
                Title = "Twice They Fall",
                Description = "Description",
                Genre = "History",
                Stock = 51,
                PublishingYear = 2003
            },
            new Book()
            {
                ID = 2,
                Author = "Lyndon B.J",
                Title = "The Whispering Trees",
                Description = "Description",
                Genre = "Thriller",
                Stock = 14,
                PublishingYear = 1968
            },
            new Book()
            {
                ID = 3,
                Author = "Me",
                Title = "How To Be Funny",
                Description = "Description.txt",
                Genre = "Comedy",
                Stock = 0,
                PublishingYear = 1569
            },
             new Book()
             {
                 ID = 4,
                 Author = "Sara Andersson",
                 Title = "Mörkret",
                 Description = "Description",
                 Genre = "Horror",
                 Stock = 7,
                 PublishingYear = 2021
             },
            new Book()
            {
                ID = 5,
                Author = "Sara Andersson",
                Title = "Gatuköket",
                Description = "Description",
                Genre = "Romance",
                Stock = 34,
                PublishingYear = 2015
            });

        }
    }
}
