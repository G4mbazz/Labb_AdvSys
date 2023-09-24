﻿// <auto-generated />
using Labb_MiniAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb_MiniAPI.Migrations
{
    [DbContext(typeof(MiniApiDbContext))]
    partial class MiniApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb_MiniAPI.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublishingYear")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Author = "George B",
                            Description = "Description",
                            Genre = "History",
                            PublishingYear = 2003,
                            Stock = 51,
                            Title = "Twice They Fall"
                        },
                        new
                        {
                            ID = 2,
                            Author = "Lyndon B.J",
                            Description = "Description",
                            Genre = "Thriller",
                            PublishingYear = 1968,
                            Stock = 14,
                            Title = "The Whispering Trees"
                        },
                        new
                        {
                            ID = 3,
                            Author = "Me",
                            Description = "Description.txt",
                            Genre = "Comedy",
                            PublishingYear = 1569,
                            Stock = 0,
                            Title = "How To Be Funny"
                        },
                        new
                        {
                            ID = 4,
                            Author = "Sara Andersson",
                            Description = "Description",
                            Genre = "Horror",
                            PublishingYear = 2021,
                            Stock = 7,
                            Title = "Mörkret"
                        },
                        new
                        {
                            ID = 5,
                            Author = "Sara Andersson",
                            Description = "Description",
                            Genre = "Romance",
                            PublishingYear = 2015,
                            Stock = 34,
                            Title = "Gatuköket"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
