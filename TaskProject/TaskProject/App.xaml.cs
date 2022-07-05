using Prism;
using Prism.Ioc;
using TaskProject.Core.Api;
using TaskProject.Core.Api.Abstractions;
using TaskProject.Core.Consts;
using TaskProject.Core.Database;
using TaskProject.Core.Database.Abstractions;
using TaskProject.Core.Database.Repositories;
using TaskProject.Core.Services;
using TaskProject.Core.Services.Abstractions;
using TaskProject.Core.ViewModels;
using TaskProject.Views;
using TaskProject.Views.Popups;
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

            await NavigationService.NavigateAsync($"{Pages.NavigationPage}/{Pages.LoginPage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IAuthApi, AuthApi>();
            containerRegistry.RegisterSingleton<IMovieApi, MovieApi>();
            containerRegistry.RegisterSingleton<IDatabase, Database>();
            containerRegistry.Register<IAuthService, AuthService>();
            containerRegistry.Register<IMovieRepository, MovieRepository>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MovieDetailsPage, MovieDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<FavouritesPage, FavouritesPageViewModel>();
            containerRegistry.RegisterForNavigation<AddMoviePopupPage, AddMoviePopupPageViewModel>();
        }
    }
}