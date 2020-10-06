using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Catel.Collections;
using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using ShipCheaperTask.Ui.Helpers;
using ShipCheaperTask.Ui.Models;
using ShipCheaperTask.Ui.Views;
using ShipCheaperTaskLibrary.Api;
using ShipCheaperTaskLibrary.Repositories;

namespace ShipCheaperTask.Ui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region dependencies

        private readonly ISearchMovieEndPoint _searchMovieEndPoint;
        private readonly IFavoriteMoviesRepository _favoriteMoviesRepository;
        private readonly MovieInfoModelsMapper _mapper;
        private readonly IUIVisualizerService _uiVisualizerService;

        #endregion

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
            CommandExecutedAsync += OnCommandExecutedAsync;
        }

        private async Task OnCommandExecutedAsync(object sender, CommandExecutedEventArgs e)
        {
            var favoriteMovies = Movies.Where(x => x.IsFavorite).ToList();
            if (e.CommandPropertyName == nameof(ShowFavoriteMoviesViewAsyncCommand) && favoriteMovies.Any())
            {
                favoriteMovies.ForEach(async x =>
                {
                    Movies.Remove(x);
                    x.IsFavorite = await _favoriteMoviesRepository.IsFavorite(x.ImdbID);
                    Movies.Add(x);
                });
            }
        }

        #endregion

        #region properties

        public string MovieTitle { get; set; }

        public string StatusText { get; set; }

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
                if (!Movies.Where(x => x.ImdbID == searchResult.ImdbID).Any())
                {
                    var uiModel = await _mapper.MapToUiModel(searchResult);
                    Movies.Add(uiModel);
                    return;
                }
                StatusText = "Already found";
                return;
            }
            StatusText = "Nothing was found";
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
            //TODO remake it to 1 window 2 usercontrols
            await _uiVisualizerService.ShowAsync<FavoritesViewModel>();
        }

        #endregion

        #endregion
    }
}