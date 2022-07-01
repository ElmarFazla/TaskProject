using Prism.Navigation;

namespace TaskProject.Core.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
        }
    }
}