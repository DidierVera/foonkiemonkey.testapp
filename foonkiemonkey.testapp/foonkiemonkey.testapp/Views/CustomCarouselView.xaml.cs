
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace foonkiemonkey.testapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCarouselView : ContentView
    {

        public static readonly BindableProperty TitleTextProperty =
            BindableProperty.Create("TitleText", typeof(string), typeof(CustomCarouselView), default(string));

        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty DescriptionTextProperty =
            BindableProperty.Create("DescriptionText", typeof(string), typeof(CustomCarouselView), default(string));

        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ImgItem", typeof(ImageSource), typeof(CustomCarouselView), default(ImageSource));

        public ImageSource ImgItem
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public CustomCarouselView()
        {
            InitializeComponent();
            lblDescription.SetBinding(Label.TextProperty, new Binding("DescriptionText", source: this));
            lblTitle.SetBinding(Label.TextProperty, new Binding("TitleText", source: this));
            imgField.SetBinding(Image.SourceProperty, new Binding("ImgItem", source: this));
        }
    }
}