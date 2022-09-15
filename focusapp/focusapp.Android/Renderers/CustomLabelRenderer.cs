using System;
using Android.Content;
using Android.Views.Accessibility;
using Android.Widget;
using focusapp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Label), typeof(CustomLabelRenderer))]
namespace focusapp.Droid.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {

        public CustomLabelRenderer(Context context) : base(context)
        {
        }

        //removes border padding for android buttons text
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
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
                Control.SetBackgroundColor(Android.Graphics.Color.White);
                Control.SetBackgroundResource(Resource.Drawable.LabelFrame);
            }
            else
            {
                Control.SetBackgroundColor(Android.Graphics.Color.White);
            }
        }
    }
}