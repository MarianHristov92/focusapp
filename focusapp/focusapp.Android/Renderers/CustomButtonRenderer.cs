using System;
using Android.Content;
using Android.Views.Accessibility;
using Android.Widget;
using focusapp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace focusapp.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        //removes border padding for android buttons text
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.FocusChange += Control_FocusChange;
                Control.SetPadding(0, 0, 0, 0);
            }
        }

        private void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (Control.HasFocus)
            {

                //Control.SetBackgroundColor(Android.Graphics.Color.);
                //Control.SetBackgroundResource(Resource.Drawable.LabelFrame);
            }
            else
            {
                //Control.SetBackgroundColor(Android.Graphics.Color.White);
            }
        }
    }
}