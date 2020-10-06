using Microsoft.EntityFrameworkCore;
using ShipCheaperTaskLibrary.Dbos;

namespace ShipCheaperTaskLibrary.Database
{
    public class DatabseContext : DbContext
    {
        public DbSet<FavoriteMovieInfo> FavoriteMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=favorites.db");
        }
    }
}