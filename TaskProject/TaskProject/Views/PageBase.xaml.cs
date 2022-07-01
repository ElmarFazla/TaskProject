using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageBase : ContentPage
    {
        /// Attached property for <seealso cref="IsLoading" />
        /// </summary>
        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(PageBase), false);

        public PageBase()
        {
            InitializeComponent();
        }

        public View MainContent
        {
            get
            {
                return mainContent.Content;
            }

            set
            {
                mainContent.Content = value;
            }
        }

        public bool IsLoading
        {
            get
            {
                return (bool)GetValue(IsLoadingProperty);
            }

            set
            {
                SetValue(IsLoadingProperty, value);
            }
        }
    }
}