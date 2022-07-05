using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class AddMoviePopupPageViewModel : PopupViewModelBase
    {
        public AddMoviePopupPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            AddMovieCommand = new Command(async () => await ExecuteAddMovieCommand());
        }

        public ICommand AddMovieCommand { get; }

        private async Task ExecuteAddMovieCommand()
        {
            // Add movie logic
            await ExecuteCloseCommand();
        }
    }
}