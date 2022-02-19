using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using foonkiemonkey.testapp.Droid.Renders;
using foonkiemonkey.testapp.Controls;
using Android.Content;

[assembly: ExportRenderer(typeof(MyFrame), typeof(MyFrameRender))]  
namespace foonkiemonkey.testapp.Droid.Renders
{
    public class MyFrameRender : FrameRenderer
    {
        public MyFrameRender(Context context): base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement as MyFrame;
            if (element == null) return;
            if (element.HasShadow)
            {
                SetOutlineAmbientShadowColor(Android.Graphics.Color.Red);
                SetOutlineSpotShadowColor(Android.Graphics.Color.Green);
                Elevation = 30.0f;
                TranslationZ = 0.0f;
                SetZ(30f);
            }
        }
    }
}