using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Consts;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class EmailSentPageViewModel : ViewModelBase
    {
        private string _email;

        public EmailSentPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Email Sent";
            BackToLoginCommand = new Command(async () => await ExecuteBackToLoginCommand());
        }

        public ICommand BackToLoginCommand { get; }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            if (parameters.TryGetValue<string>(NavigationParameterKeys.Email, out string email))
            {
                Email = email;
            }
        }

        private async Task ExecuteBackToLoginCommand()
        {
            await NavigationService.NavigateAsync($"/{Pages.NavigationPage}/{Pages.LoginPage}");
        }
    }
}