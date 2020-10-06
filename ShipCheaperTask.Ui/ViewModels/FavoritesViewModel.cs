namespace ShipCheaperTask.Ui.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using ShipCheaperTask.Ui.Helpers;
    using ShipCheaperTask.Ui.Models;
    using ShipCheaperTaskLibrary.Repositories;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    public class FavoritesViewModel : ViewModelBase
    {
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;
        private readonly MovieInfoModelsMapper _movieInfoModelsMapper;

        public FavoritesViewModel(IFavoriteMoviesRepository favoriteMoviesRepository,
            MovieInfoModelsMapper movieInfoModelsMapper)
        {
            _favoriteMoviesRepository = favoriteMoviesRepository;
            _movieInfoModelsMapper = movieInfoModelsMapper;

            Movies = new ObservableCollection<MovieInfoUiModel>();

            RemoveAsync = new TaskCommand<MovieInfoUiModel>(OnRemoveAsyncExecute);
        }

        protected override async Task InitializeAsync()
        {
            var favmovies = await _favoriteMoviesRepository.GetAllAsync();
            foreach (var favmovie in favmovies)
            {
                Movies.Add(await _movieInfoModelsMapper.MapToUiModel(favmovie));
            }

            await base.InitializeAsync();
        }

        public ObservableCollection<MovieInfoUiModel> Movies { get; set; }


        public TaskCommand<MovieInfoUiModel> RemoveAsync { get; private set; }

        private async Task OnRemoveAsyncExecute(MovieInfoUiModel selectedMovie)
        {
            await _favoriteMoviesRepository.DeleteAsync(selectedMovie.ImdbID);
            Movies.Remove(selectedMovie);
        }
    }
}