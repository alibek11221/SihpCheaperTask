using ShipCheaperTaskLibrary.Dbos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShipCheaperTaskLibrary.Repositories
{
    public interface IFavoriteMoviesRepository
    {
        Task DeleteAsync(int id);
        Task<List<FavoriteMovieInfo>> GetAllAsync();
        Task<FavoriteMovieInfo> GetMovieInfoAsync(int id);
        Task SaveAsync(FavoriteMovieInfo favoriteMovie);
    }
}