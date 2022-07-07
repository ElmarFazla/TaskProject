using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskProject.Core.Consts;
using TaskProject.Core.Infrastructure.Commands;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class ForgotPasswordPageViewModel : ViewModelBase
    {
        private string _email;

        public ForgotPasswordPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Forgot Password";

            SendEmailCommand = new AsyncCommand(async () => await ExecuteSendEmailCommand(), () => CanExecuteSendEmail);
        }

        public AsyncCommand SendEmailCommand { get; }

        public bool CanExecuteSendEmail
        {
            get
            {
                return !string.IsNullOrEmpty(Email);
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if(SetProperty(ref _email, value))
                {
                    SendEmailCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private async Task ExecuteSendEmailCommand()
        {
            var navParams = new NavigationParameters();
            navParams.Add(NavigationParameterKeys.Email, Email);

            await NavigationService.NavigateAsync(Pages.EmailSentPage, navParams);
        }
    }
}