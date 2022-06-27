using Prism.Navigation;

namespace TaskProject.Core.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Home Page";
        }
    }
}
