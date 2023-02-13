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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieModel>().HasData(
                new MovieModel()
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
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
                    Category = "Fantasy",
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
                    Category = "Action/Adventure",
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
