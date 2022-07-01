using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskProject.Common.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PillView : Frame
    {
        /// Attached property for <seealso cref="Text" />
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(PillView), string.Empty);

        /// Attached property for <seealso cref="TextColor" />
        /// </summary>
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(PillView), Color.Default);

        public PillView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }

            set
            {
                SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets TextColor
        /// </summary>
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }

            set
            {
                SetValue(TextColorProperty, value);
            }
        }
    }
}