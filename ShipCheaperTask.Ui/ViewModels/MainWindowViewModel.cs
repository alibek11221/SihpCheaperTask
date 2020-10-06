using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Catel.MVVM;
using Catel.Services;
using ShipCheaperTask.Ui.Helpers;
using ShipCheaperTask.Ui.Models;
using ShipCheaperTaskLibrary.Api;
using ShipCheaperTaskLibrary.Repositories;

namespace ShipCheaperTask.Ui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region ctor

        public MainWindowViewModel(ISearchMovieEndPoint searchMovieEndPoint,
            IFavoriteMoviesRepository favoriteMoviesRepository,
            MovieInfoModelsMapper mapper,
            IUIVisualizerService uiVisualizerService)
        {
            _searchMovieEndPoint = searchMovieEndPoint;
            _favoriteMoviesRepository = favoriteMoviesRepository;
            _mapper = mapper;
            _uiVisualizerService = uiVisualizerService;
            Movies = new ObservableCollection<MovieInfoUiModel>();


            SearchMovieAsyncCommand = new TaskCommand(OnSearchMovieAsyncExecute);
            SaveToFavoriteAsyncCommand = new TaskCommand<MovieInfoUiModel>(OnSaveToFavoriteExecuteAsync);
            ShowFavoriteMoviesViewAsyncCommand = new TaskCommand(OnShowViewExecuteAsync);
        }

        #endregion

        #region dependencies

        private readonly ISearchMovieEndPoint _searchMovieEndPoint;
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;
        private readonly MovieInfoModelsMapper _mapper;
        private readonly IUIVisualizerService _uiVisualizerService;

        #endregion

        #region properties

        public string MovieTitle { get; set; }
        public ObservableCollection<MovieInfoUiModel> Movies { get; set; }

        #endregion

        #region commands

        #region searchcommand

        public TaskCommand SearchMovieAsyncCommand { get; set; }

        private async Task OnSearchMovieAsyncExecute()
        {
            var searchResult = await _searchMovieEndPoint.GetMoviesByTitle(MovieTitle);
            if (searchResult != null)
            {
                var uiModel = await _mapper.MapToUiModel(searchResult);
                Movies.Add(uiModel);
            }
            else
            {
                MessageBox.Show("No results");
            }
        }

        #endregion

        #region SaveCommand

        public TaskCommand<MovieInfoUiModel> SaveToFavoriteAsyncCommand { get; set; }

        private async Task OnSaveToFavoriteExecuteAsync(MovieInfoUiModel movie)
        {
            if (movie.IsFavorite)
            {
                var modelToSave = _mapper.MapToDbModel(movie);
                await _favoriteMoviesRepository.SaveAsync(modelToSave);
            }
            else
            {
                await _favoriteMoviesRepository.DeleteAsync(movie.ImdbID);
            }
        }

        #endregion

        #region ShowFavoriteMoviesViewCommand

        public TaskCommand ShowFavoriteMoviesViewAsyncCommand { get; set; }

        private async Task OnShowViewExecuteAsync()
        {
            await _uiVisualizerService.ShowAsync<FavoritesViewModel>();
        }

        #endregion

        #endregion
    }
}