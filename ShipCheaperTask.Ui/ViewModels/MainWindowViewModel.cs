using Catel.Collections;
using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using ShipCheaperTask.Ui.Helpers;
using ShipCheaperTask.Ui.Models;

using ShipCheaperTaskLibrary.Api;
using ShipCheaperTaskLibrary.Models;
using ShipCheaperTaskLibrary.Repositories;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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


            SearchCommand = new TaskCommand(OnSearchExecuteAsync);
            SaveToFavoriteAsyncCommand = new TaskCommand(OnSaveToFavoriteExecuteAsync);
            ShowViewCommand = new TaskCommand(OnShowViewExecuteAsync);
        }
        #endregion
        #region properties
        public string MovieTitle { get; set; }
        [Model]
        public SearchResults SearchResults { get; set; }
        [ViewModelToModel(nameof(SearchResults))]
        public ObservableCollection<MovieInfoUiModel> Movies { get; set; }


        public MovieInfoUiModel SelectedMovie { get; set; }

        #endregion
        #region commands
        #region searchcommand
        public TaskCommand SearchCommand { get; set; }
        private async Task OnSearchExecuteAsync()
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
        public TaskCommand SaveToFavoriteAsyncCommand { get; set; }
        private async Task OnSaveToFavoriteExecuteAsync()
        {
            if (SelectedMovie.IsFavorite)
            {
                var modelToSave = _mapper.MapToDbModel(SelectedMovie);
                await _favoriteMoviesRepository.SaveAsync(modelToSave);
            }
            else
            {
                await _favoriteMoviesRepository.DeleteAsync(SelectedMovie.ImdbID);
            }
        }
        #endregion

        public TaskCommand ShowViewCommand { get; set; }

        private async Task OnShowViewExecuteAsync()
        {
            await _uiVisualizerService.Show<FavoritesViewModel>();
        }
        #endregion

    }
}
