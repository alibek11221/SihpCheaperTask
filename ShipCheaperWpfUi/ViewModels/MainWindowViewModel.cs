using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using ShipCheaperTaskLibrary.Api;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ShipCheaperWpfUi.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(ISearchMovieEndPoint searchMovieEndPoint)
        {
            SearchCommand = new TaskCommand(OnSearchCommandExecuteAsync);
            _searchMovieEndPoint = searchMovieEndPoint;
        }


        public TaskCommand SearchCommand { get; private set; }


        private async Task OnSearchCommandExecuteAsync()
        {
            var movieInfo = await _searchMovieEndPoint.GetMoviesByTitle(MovieTitile);
            if (movieInfo != null)
            {
                var output = await _mapper.MapMovieInfoToMovieInfoModel(movieInfo);
                Movies.Add(output);
            }
        }

        public string MovieTitile
        {
            get { return GetValue<string>(MovieTitileProperty); }
            set { SetValue(MovieTitileProperty, value); }
        }

        public static readonly PropertyData MovieTitileProperty = RegisterProperty(nameof(MovieTitile), typeof(string), null);
        private readonly ISearchMovieEndPoint _searchMovieEndPoint;

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();
        }

        protected override async Task CloseAsync()
        {
            await base.CloseAsync();
        }
    }
}