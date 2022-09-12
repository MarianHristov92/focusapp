using System;
using Android.Content;
using Android.Views.Accessibility;
using Android.Widget;
using focusapp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Label), typeof(CustomLabelRenderer))]
namespace focusapp.Droid.Renderers
{
    public class CustomLabelRenderer : ViewRenderer<Label, TextView>
    {
        Context context;
        TextView textView;

        public CustomLabelRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            var label = (Label)Element;
            if (label == null)
                return;
            textView = new TextView(this.Context);

            textView.Enabled = true;
            textView.Focusable = true;
            textView.LongClickable = true;
            textView.SetTextIsSelectable(true);

            // Initial properties Set
            textView.Text = label.Text;
            textView.SetBackgroundColor(Android.Graphics.Color.White);
            textView.SetTextColor(Android.Graphics.Color.Black);

            textView.TextSize = (float)label.FontSize;
            textView.OnInitializeAccessibilityEvent();

            SetNativeControl(textView);

            if (Control == null)
            {
                return;
            }

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

        protected override Android.Widget.TextView CreateNativeControl()
        {
            return new AccessibleLabel(context);
        }
    }

    public class AccessibleLabel : Android.Widget.TextView
    {

        public AccessibleLabel(Context context) : base(context)
        {
            Console.WriteLine($"***** AccessibleButton created *****");
        }

        
    }
}

