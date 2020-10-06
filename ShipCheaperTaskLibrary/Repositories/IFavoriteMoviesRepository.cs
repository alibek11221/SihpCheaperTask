using System.Collections.Generic;
using System.Threading.Tasks;
using ShipCheaperTaskLibrary.Models;

namespace ShipCheaperTaskLibrary.Repositories
{
    public interface IFavoriteMoviesRepository
    {
        Task DeleteAsync(string id);
        Task<List<MovieInfo>> GetAllAsync();
        Task<MovieInfo> GetMovieInfoAsync(string imdbid);
        Task SaveAsync(MovieInfo favoriteMovie);
        Task<bool> IsFavorite(string imdbid);
    }
}