using Xamarin.Forms.Xaml;

namespace TaskProject.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMoviePopupPage : PopupPageBase
    {
        public AddMoviePopupPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
                var test = 1;
            }
        }
    }
}