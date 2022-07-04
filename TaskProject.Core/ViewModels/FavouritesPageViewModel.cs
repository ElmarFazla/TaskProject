using Prism.Events;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Database.Abstractions;
using TaskProject.Core.Models;
using TaskProject.Core.Models.Events;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class FavouritesPageViewModel : ViewModelBase
    {
        private readonly IMovieRepository _movieRepository;

        private IEnumerable<Movie> _favouriteMovies;
        private bool _isRefreshing;

        public FavouritesPageViewModel(INavigationService navigationService, IMovieRepository movieRepository, IEventAggregator eventAggregator)
           : base(navigationService)
        {
            _movieRepository = movieRepository;

            Title = "Favourites";

            RefreshFavouritesCommand = new Command(async () => await ExecuteRefreshFavouritesCommand());

            eventAggregator
                .GetEvent<RefreshFavouritesEvent>()
                .Subscribe(HandleMyEvent);
        }

        public ICommand RefreshFavouritesCommand { get; }

        public IEnumerable<Movie> FavouriteMovies
        {
            get
            {
                return _favouriteMovies;
            }
            set
            {
                SetProperty(ref _favouriteMovies, value);
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                SetProperty(ref _isRefreshing, value);
            }
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            await ExecuteRefreshFavouritesCommand();
        }

        private async void HandleMyEvent()
        {
            await ExecuteRefreshFavouritesCommand();
        }

        private async Task ExecuteRefreshFavouritesCommand()
        {
            FavouriteMovies = await _movieRepository.GetMovies();
            IsRefreshing = false;
        }
    }
}