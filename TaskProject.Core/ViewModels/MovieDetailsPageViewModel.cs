using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Consts;
using TaskProject.Core.Models;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class MovieDetailsPageViewModel : ViewModelBase
    {
        private readonly IMovieApi _movieApi;

        private MovieExtended _movieDetails;

        public MovieDetailsPageViewModel(INavigationService navigationService, IMovieApi movieApi)
            : base(navigationService)
        {
            _movieApi = movieApi;

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
                MovieDetails = await _movieApi.GetMovieDetails(movieId);
            }
            DisableLoader();
        }

        private async Task ExecuteAddToFavouriteCommand()
        {
            // Add to LocalDB for Movies
        }
    }
}
