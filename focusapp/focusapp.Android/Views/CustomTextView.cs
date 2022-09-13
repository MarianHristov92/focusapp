using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views.Accessibility;
using Android.Widget;

namespace focusapp.Droid.Views
{
    public class CustomTextView : TextView
    {
        public CustomTextView(Context context) : base(context)
        {
        }

        public CustomTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CustomTextView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public CustomTextView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected CustomTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
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

