using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class AddMoviePopupPageViewModel : PopupViewModelBase
    {
        private string _movieTitle;
        private string _year;
        private string _director;
        private string _synopsis;

        public AddMoviePopupPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            AddMovieCommand = new Command(async () => await ExecuteAddMovieCommand());
        }

        public ICommand AddMovieCommand { get; }

        public string MovieTitle
        {
            get
            {
                return _movieTitle;
            }
            set
            {
                SetProperty(ref _movieTitle, value);
            }
        }

        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                SetProperty(ref _year, value);
            }
        }

        public string Director
        {
            get
            {
                return _director;
            }
            set
            {
                SetProperty(ref _director, value);
            }
        }

        public string Synopsis
        {
            get
            {
                return _synopsis;
            }
            set
            {
                SetProperty(ref _synopsis, value);
            }
        }

        private async Task ExecuteAddMovieCommand()
        {
            // Add movie logic
            await ExecuteCloseCommand();
        }
    }
}