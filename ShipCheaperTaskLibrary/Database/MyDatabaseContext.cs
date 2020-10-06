using Microsoft.EntityFrameworkCore;
using ShipCheaperTaskLibrary.Models;
using System;
using System.IO;

namespace ShipCheaperTaskLibrary.Database
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<MovieInfo> FavoriteMovies { get; set; }

        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {
        }

    }
}