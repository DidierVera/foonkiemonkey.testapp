using Android.Content;
using foonkiemonkey.testapp.Controls;
using foonkiemonkey.testapp.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace foonkiemonkey.testapp.Droid.Renders
{
    public class MyButtonRenderer : ButtonRenderer
    {
        public MyButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            var button = this.Control;
            button.SetAllCaps(false);
        }
    }
}