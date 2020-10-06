using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShipCheaperTaskLibrary.Database;
using ShipCheaperTaskLibrary.Models;

namespace ShipCheaperTaskLibrary.Repositories
{
    public class FavoriteMoviesRepository : IFavoriteMoviesRepository
    {
        private readonly MyDatabaseContext _myDatabaseContext;

        public FavoriteMoviesRepository(MyDatabaseContext myDatabaseContext)
        {
            _myDatabaseContext = myDatabaseContext;
        }

        public async Task<List<MovieInfo>> GetAllAsync()
        {
            return await _myDatabaseContext.FavoriteMovies.ToListAsync();
        }

        public async Task<MovieInfo> GetMovieInfoAsync(string imdbid)
        {
            return await _myDatabaseContext.FavoriteMovies.FindAsync(imdbid);
        }

        public async Task SaveAsync(MovieInfo favoriteMovie)
        {
            await _myDatabaseContext.FavoriteMovies.AddAsync(favoriteMovie);
            await _myDatabaseContext.SaveChangesAsync();
        }

        public async Task<bool> IsFavorite(string imdbid)
        {
            return await GetMovieInfoAsync(imdbid) != null;
        }

        public async Task DeleteAsync(string imdbid)
        {
            var movieToDelete = await GetMovieInfoAsync(imdbid);
            _myDatabaseContext.FavoriteMovies.Remove(movieToDelete);
            await _myDatabaseContext.SaveChangesAsync();
        }
    }
}