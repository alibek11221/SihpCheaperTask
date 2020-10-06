using ShipCheaperTaskLibrary.Models;
using System.Threading.Tasks;

namespace ShipCheaperTaskLibrary.Api
{
    public interface ISearchMovieEndPoint
    {
        Task<MovieInfo> GetMoviesByTitle(string title);
    }
}