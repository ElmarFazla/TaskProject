using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaskProject.Core.ViewModels
{
    public class PopupViewModelBase : ViewModelBase
    {
        public PopupViewModelBase(INavigationService navigationService)
            : base(navigationService)
        {
            CloseCommand = new Command(async () => await ExecuteCloseCommand());
        }

        public ICommand CloseCommand { get; }

        protected virtual async Task ExecuteCloseCommand()
        {
            var test = await NavigationService.GoBackAsync();
        }
    }
}