using System;
using Android.Content;
using Android.Views.Accessibility;
using Android.Widget;
using focusapp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace focusapp.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        Context context;

        public CustomButtonRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            Console.WriteLine("created from Android");
            Control.SetBackgroundColor(Android.Graphics.Color.Red);
        }

        protected override Android.Widget.Button CreateNativeControl()
        {
            return new AccessibleButton(context);
        }
    }

    public class AccessibleButton : Android.Widget.Button
    {
        public AccessibleButton(Context context) : base(context)
        {
            Console.WriteLine($"***** AccessibleButton created *****");
        }

        public override void OnInitializeAccessibilityEvent(AccessibilityEvent e)
        {
            base.OnInitializeAccessibilityEvent(e);
            if (e.EventType == EventTypes.ViewAccessibilityFocused)
            {
                this.SetBackgroundColor(Android.Graphics.Color.Green);
                Console.WriteLine("I am in focus");
            }
            else if (e.EventType == EventTypes.ViewAccessibilityFocusCleared)
            {
                this.SetBackgroundColor(Android.Graphics.Color.Red);
                Console.WriteLine("I am in NOT in focus");
            }
        }
    }
}

