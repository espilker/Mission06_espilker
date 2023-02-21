using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_espilker.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {

        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Fantasy"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Comedy"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Horror"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Romantic"
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Romantic/Comedy"
                });
            mb.Entity<MovieModel>().HasData(
                new MovieModel()
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Best movie"
                },
                new MovieModel()
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "The Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieModel()
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "Guardians of the Galaxy",
                    Year = 2014,
                    Director = "James Gunn",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}
