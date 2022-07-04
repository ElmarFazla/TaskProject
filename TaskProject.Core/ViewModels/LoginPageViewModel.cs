using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Consts;
using TaskProject.Core.Database.Abstractions;
using TaskProject.Core.Services.Abstractions;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IDatabase _database;
        private readonly IAuthService _authService;

        private string _userName;
        private string _password;

        public LoginPageViewModel(INavigationService navigationService, IDatabase database, IAuthService authService)
            : base(navigationService)
        {
            _database = database;
            _authService = authService;

            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        public ICommand LoginCommand { get; }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        private async Task ExecuteLoginCommand()
        {
            await _authService.Login(UserName, Password);

            // UserName is added for Db creation so that every user had its own DB on the Device
            await _database.ConnectAsync(UserName);

            await NavigationService.NavigateAsync($"../{Pages.MainPage}");
        }
    }
}
