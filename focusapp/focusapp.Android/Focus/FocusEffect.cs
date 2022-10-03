using System;
using focusapp.Droid.Focus;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Views.View;

[assembly: ResolutionGroupName("FocusApp")]
[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]
namespace focusapp.Droid.Focus
{
    public class FocusEffect : PlatformEffect
    {
        Android.Graphics.Color backgroundColor;

        public Android.Graphics.Drawables.Drawable OriginalBackground { get; private set; }

        protected override void OnAttached()
        {
            try
            {
                OriginalBackground = Container.Background;
                if (Control != null)
                {
                    Control.FocusChange += Control_FocusChange;
                }
                else
                {
                    Container.FocusChange += Control_FocusChange;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
        }

        private void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (Control != null)
            {
                if (Control.HasFocus)
                {
                    Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    Control.SetPadding(6, 6, 6, 6);
                    Control.SetBackgroundResource(Resource.Drawable.LabelFrame);
                }
                else
                {
                    Control.SetBackground(OriginalBackground);
                    Control.SetPadding(0, 0, 0, 0);
                }
            }
            else
            {
                if (Container.HasFocus)
                {
                    Container.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    Container.SetPadding(6, 6, 6, 6);
                    Container.SetBackgroundResource(Resource.Drawable.LabelFrame);
                }
                else
                {
                    Container.SetBackground(OriginalBackground);
                    Container.SetPadding(0, 0, 0, 0);
                }
            }
        }
    }
}