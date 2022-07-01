using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.CurrentPageChanged += TabbedPageCurrentPageChanged;
        }

        protected override void OnAppearing()
        {
            Title = CurrentPage.Title;
        }

        private void TabbedPageCurrentPageChanged(object sender, System.EventArgs e)
        {
            Title = CurrentPage.Title;
        }
    }
}