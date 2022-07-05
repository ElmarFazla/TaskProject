using Rg.Plugins.Popup.Pages;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskProject.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPageBase : PopupPage
    {
        /// <summary>
        /// Bindable property for <seealso cref="Title" />
        /// </summary>
        public static readonly new BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(PopupPageBase), null);

        /// <summary>
        /// Bindable property for <seealso cref="Description" />
        /// </summary>
        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(nameof(Description), typeof(string), typeof(PopupPageBase), null);

        /// <summary>
        /// Bindable property for <seealso cref="CloseCommand" />
        /// </summary>
        public static readonly BindableProperty CloseCommandProperty =
            BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(PopupPageBase), null);

        public PopupPageBase()
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

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public new string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }

            set
            {
                SetValue(DescriptionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets MainContent
        /// </summary>
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

        /// <summary>
        /// Gets or sets Footer
        /// </summary>
        public View Footer
        {
            get
            {
                return footer.Content;
            }

            set
            {
                footer.Content = value;
            }
        }

        /// <summary>
        /// Gets or sets CloseCommand
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                return (ICommand)GetValue(CloseCommandProperty);
            }

            set
            {
                SetValue(CloseCommandProperty, value);
            }
        }
    }
}