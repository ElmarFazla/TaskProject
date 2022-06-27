using Prism;
using Prism.Ioc;
using TaskProject.Core.Consts;
using TaskProject.Core.ViewModels;
using TaskProject.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TaskProject
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            await NavigationService.NavigateAsync($"{Pages.NavigationPage}/{Pages.LoginPage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}
