using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carte2ct_Final.Models
{
    public class GameContext : DbContext
    {


        public GameContext(DbContextOptions<GameContext> options)
            : base(options)

        { }

        public DbSet<Games> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>().HasKey(global => global.GameId);

            modelBuilder.Entity<Games>().HasData(
                new Games
                {
                    GameId = 4,
                    Name = "Doom",
                    Year = 1993,
                    Rating = 5,
                    GenreId = "AA"
                },
                new Games
                {
                    GameId = 2,
                    Name = "Halo",
                    Year = 2001,
                    Rating = 3,
                    GenreId = "A"
                },
                new Games
                {
                    GameId = 3,
                    Name = "Sonic",
                    Year = 1991,
                    Rating = 4,
                    GenreId = "S"
                }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "A", Name = "Action" },
                new Genre { GenreId = "AA", Name = "Adventure" },
                new Genre { GenreId = "R", Name = "RPG" },
                new Genre { GenreId = "S", Name = "Strategy" },
                new Genre { GenreId = "M", Name = "MMO" }
            );
        }
    }


}

