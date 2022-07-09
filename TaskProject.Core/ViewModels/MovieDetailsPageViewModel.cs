using Prism.Events;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Consts;
using TaskProject.Core.Database.Abstractions;
using TaskProject.Core.Models;
using TaskProject.Core.Models.Events;
using TaskProject.Core.Services.Abstractions;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class MovieDetailsPageViewModel : ViewModelBase
    {
        private readonly IMovieApiManager _movieApiManager;
        private readonly IMovieRepository _movieRepository;
        private readonly IEventAggregator _eventAggregator;

        private MovieExtended _movieDetails;

        public MovieDetailsPageViewModel(INavigationService navigationService, IMovieApiManager movieApiManager, IMovieRepository movieRepository, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            _movieApiManager = movieApiManager;
            _movieRepository = movieRepository;
            _eventAggregator = eventAggregator;

            Title = "Movies Details";

            AddToFavouriteCommand = new Command(async () => await ExecuteAddToFavouriteCommand());
        }

        public ICommand AddToFavouriteCommand { get; }

        public MovieExtended MovieDetails
        {
            get
            {
                return _movieDetails;
            }
            set
            {
                SetProperty(ref _movieDetails, value);
            }
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            EnableLoader();
            base.Initialize(parameters);

            if (parameters.TryGetValue<string>(NavigationParameterKeys.MovieId, out string movieId))
            {
                MovieDetails = await _movieApiManager.GetMovieDetails(movieId);
            }

            DisableLoader();
        }

        private async Task ExecuteAddToFavouriteCommand()
        {
            var movie = new Movie
            {
                ImdbID = MovieDetails.ImdbID,
                Poster = MovieDetails.Poster,
                Title = MovieDetails.Title,
                Year = MovieDetails.Year
            };

            await _movieRepository.AddMovie(movie);
            _eventAggregator
                .GetEvent<RefreshFavouritesEvent>()
                .Publish();
        }
    }
}