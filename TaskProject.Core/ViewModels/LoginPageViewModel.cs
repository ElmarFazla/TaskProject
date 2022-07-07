using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Consts;
using TaskProject.Core.Database.Abstractions;
using TaskProject.Core.Infrastructure.Commands;
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

            LoginCommand = new AsyncCommand(async () => await ExecuteLoginCommand(), () => CanExecuteLogin);
            ForgotPasswordCommand = new Command(async () => await ExecuteForgotPasswordCommand());
        }

        public AsyncCommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public bool CanExecuteLogin => !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if(SetProperty(ref _userName, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
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
                if (SetProperty(ref _password, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private async Task ExecuteLoginCommand()
        {
            await _authService.Login(UserName, Password);

            // UserName is added for Db creation so that every user had its own DB on the Device
            await _database.ConnectAsync(UserName);

            await NavigationService.NavigateAsync($"../{Pages.MainPage}");
        }

        private async Task ExecuteForgotPasswordCommand()
        {
            await NavigationService.NavigateAsync(Pages.ForgotPasswordPage);
        }
    }
}