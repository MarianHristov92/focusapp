using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views.Accessibility;
using Android.Widget;
using focusapp.Droid.Renderers;
using focusapp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace focusapp.Droid.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {

        public CustomLabelRenderer(Context context) : base(context)
        {
        }

        //removes border padding for android buttons text
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.FocusChange += Control_FocusChange;
                Control.SetPadding(0, 0, 0, 0);
            }
        }

        private GradientDrawable _gradientBackground;

        private void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (Control.HasFocus)
            {
                var view = (CustomLabel)Element;
                Paint(view);
            }
            else
            {
                Control.SetBackgroundColor(Android.Graphics.Color.White);
            }
        }

        private void Paint(CustomLabel view)
        {
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(view.CustomBackgroundColor.ToAndroid());
            // Thickness of the stroke line  
            _gradientBackground.SetStroke((int)view.CustomBorderWidth, Android.Graphics.Color.Red);
            // Radius for the curves  
            _gradientBackground.SetCornerRadius(
                DpToPixels(this.Context, Convert.ToSingle(view.CustomBorderRadius)));
            // set the background of the label  
            Control.SetBackground(_gradientBackground);
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}