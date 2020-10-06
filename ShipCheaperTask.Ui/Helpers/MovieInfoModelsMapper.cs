using ShipCheaperTask.Ui.Models;
using ShipCheaperTaskLibrary.Models;
using ShipCheaperTaskLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ShipCheaperTask.Ui.Helpers
{
    public class MovieInfoModelsMapper
    {
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;

        public MovieInfoModelsMapper(IFavoriteMoviesRepository favoriteMoviesRepository)
        {
            _favoriteMoviesRepository = favoriteMoviesRepository;
        }
        public async Task<MovieInfoUiModel> MapToUiModel(MovieInfo movie) => new MovieInfoUiModel
        {
            MovieTitle = movie.Title,
            Poster = new BitmapImage(new Uri(movie.Poster, UriKind.Absolute)),
            Runtime = movie.Runtime,
            Genre = movie.Genre,
            ImdbID = movie.ImdbID,
            Writer = movie.Writer,
            Year = movie.Year,
            IsFavorite = await _favoriteMoviesRepository.IsFavorite(movie.ImdbID),
        };

        public MovieInfo MapToDbModel(MovieInfoUiModel uiModel) => new MovieInfo
        {
            ImdbID = uiModel.ImdbID,
            Title = uiModel.MovieTitle,
            Poster = uiModel.Poster.ToString(),
            Genre = uiModel.Genre,
            IsFavorite = uiModel.IsFavorite,
            Runtime = uiModel.Runtime,
            Writer = uiModel.Writer,
            Year = uiModel.Year
        };
    }
}
