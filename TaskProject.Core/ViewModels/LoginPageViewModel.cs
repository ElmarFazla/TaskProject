using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Consts;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        public ICommand LoginCommand { get; }

        private async Task ExecuteLoginCommand()
        {
            await NavigationService.NavigateAsync($"../{Pages.HomePage}");
        }
    }
}
