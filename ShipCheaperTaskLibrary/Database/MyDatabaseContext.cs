using Microsoft.EntityFrameworkCore;
using ShipCheaperTaskLibrary.Models;

namespace ShipCheaperTaskLibrary.Database
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<MovieInfo> FavoriteMovies { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=favorites.db");
    }
}