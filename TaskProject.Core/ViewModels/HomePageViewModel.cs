using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Consts;
using TaskProject.Core.Models;
using TaskProject.Core.Services.Abstractions;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly IMovieApiManager _movieApiManager;

        private IEnumerable<Movie> _movies;
        private string _searchText;
        private CancellationTokenSource throttleCts = new CancellationTokenSource();

        public HomePageViewModel(INavigationService navigationService, IMovieApiManager movieApiManager)
            : base(navigationService)
        {
            _movieApiManager = movieApiManager;

            Title = "Movies List";

            OpenMovieDetailsCommand = new Command<string>(async (movieID) => await ExecuteOpenMovieDetailsCommand(movieID));
            SearchCommand = new Command(async () => await ExecuteSearchCommand());
            AddMovieCommand = new Command(async () => await ExecuteAddMovieCommand());
        }

        public ICommand OpenMovieDetailsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand AddMovieCommand { get; }

        public IEnumerable<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                SetProperty(ref _movies, value);
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    DelayedSearch();
                }
            }
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            EnableLoader();
            Movies = await _movieApiManager.GetInitialMovies();
            DisableLoader();
        }

        private async Task ExecuteOpenMovieDetailsCommand(string movieId)
        {
            var navParams = new NavigationParameters();
            navParams.Add(NavigationParameterKeys.MovieId, movieId);

            await NavigationService.NavigateAsync(Pages.MovieDetailsPage, navParams);
        }

        private async Task ExecuteSearchCommand()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Movies = await _movieApiManager.GetInitialMovies();
            }

            if (SearchText.Length >= 4)
            {
                Movies = await _movieApiManager.SearchMovies(SearchText);
            }
        }

        private async Task ExecuteAddMovieCommand()
        {
            await NavigationService.NavigateAsync(Pages.AddMoviePopupPage, useModalNavigation: true );
        }

        private void DelayedSearch()
        {
            Interlocked.Exchange(ref this.throttleCts, new CancellationTokenSource()).Cancel();
            Task.Delay(TimeSpan.FromMilliseconds(500), this.throttleCts.Token)
                .ContinueWith(
                    (t) => ExecuteSearchCommand(),
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
