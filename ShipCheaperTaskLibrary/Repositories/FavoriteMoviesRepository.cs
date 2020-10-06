using Microsoft.EntityFrameworkCore;
using ShipCheaperTaskLibrary.Database;
using ShipCheaperTaskLibrary.Dbos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShipCheaperTaskLibrary.Repositories
{
    public class FavoriteMoviesRepository : IFavoriteMoviesRepository
    {
        private readonly DatabseContext _databseContext;

        public FavoriteMoviesRepository(DatabseContext databseContext)
        {
            _databseContext = databseContext;
        }

        public async Task<List<FavoriteMovieInfo>> GetAllAsync()
        {
            return await _databseContext.FavoriteMovies.ToListAsync();
        }

        public async Task<FavoriteMovieInfo> GetMovieInfoAsync(int id)
        {
            return await _databseContext.FavoriteMovies.FindAsync(id);
        }

        public async Task SaveAsync(FavoriteMovieInfo favoriteMovie)
        {
            await _databseContext.FavoriteMovies.AddAsync(favoriteMovie);
            await _databseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movieToDelete = await GetMovieInfoAsync(id);
            _databseContext.FavoriteMovies.Remove(movieToDelete);
            await _databseContext.SaveChangesAsync();
        }
    }
}
