using System.Threading.Tasks;
using ShipCheaperTaskLibrary.Models;
using ShipCheaperTaskLibrary.Repositories;
using ShipCheaperWpfUi.Models;

namespace ShipCheaperWpfUi.Mapper
{
    public class MovieInfoMapper
    {
        private readonly IFavoriteMoviesRepository _moviesRepository;

        public MovieInfoMapper(IFavoriteMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<MovieInfoUiModel> MapMovieInfoToMovieInfoModel(MovieInfo movieInfo)
        {
            if (movieInfo == null)
            {
                return null;
            }

            var output = new MovieInfoUiModel()
            { 
                IsFavorite = await _moviesRepository.IsFavorite(movieInfo.ImdbID)
            };
            return output.;
        }
        public MovieInfo MapMovieInfoModelToMovieInfo(MovieInfoUiModel movieInfoModel)
        {
            if (movieInfoModel == null)
            {
                return null;
            }

            var output = new MovieInfo()
            {
                ImdbID = movieInfoModel.ImdbId,
                Title = movieInfoModel.TitleOfMovie,
                Poster = movieInfoModel.Poster,
                Genre = movieInfoModel.Genre,
                Runtime = movieInfoModel.Runtime,
                Year = movieInfoModel.Year,
                Writer = movieInfoModel.Writer,
                IsFavorite = movieInfoModel.IsFavorite
            };
            return output;
        }
    }
}