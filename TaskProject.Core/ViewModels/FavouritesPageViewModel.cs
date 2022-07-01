using Prism.Navigation;
using System.Collections.Generic;
using TaskProject.Core.Models;

namespace TaskProject.Core.ViewModels
{
    public class FavouritesPageViewModel : ViewModelBase
    {
        private IEnumerable<Movie> _favouriteMovies;

        public FavouritesPageViewModel(INavigationService navigationService)
           : base(navigationService)
        {
            Title = "Favourites";
        }
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
    }
}