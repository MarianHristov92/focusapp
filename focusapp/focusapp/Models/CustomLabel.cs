using System;
using Xamarin.Forms;

namespace focusapp.Models
{
    public class CustomLabel : Label
    {
        public static readonly BindableProperty CustomBorderColorProperty =
          BindableProperty.Create(
              nameof(CustomBorderColor),
              typeof(Color),
              typeof(CustomLabel),
              Color.Default);

        public Color CustomBorderColor
        {
            get { return (Color)GetValue(CustomBorderColorProperty); }
            set { SetValue(CustomBorderColorProperty, value); }
        }

        public static readonly BindableProperty CustomBorderRadiusProperty =
             BindableProperty.Create(
                 nameof(CustomBorderRadius),
                 typeof(int),
                 typeof(CustomLabel),
                 4);

        public int CustomBorderRadius
        {
            get { return (int)GetValue(CustomBorderRadiusProperty); }
            set { SetValue(CustomBorderRadiusProperty, value); }
        }

        public static readonly BindableProperty CustomBorderWidthProperty =
             BindableProperty.Create(
                 nameof(CustomBorderWidth),
                 typeof(double),
                 typeof(CustomLabel),
                 4.0);

        public double CustomBorderWidth
        {
            get { return (double)GetValue(CustomBorderWidthProperty); }
            set { SetValue(CustomBorderWidthProperty, value); }
        }

        public static readonly BindableProperty CustomBackgroundColorProperty =
           BindableProperty.Create(
               nameof(CustomBorderColor),
               typeof(Color),
               typeof(CustomLabel),
               Color.Default
              );

        public Color CustomBackgroundColor
        {
            get { return (Color)GetValue(CustomBackgroundColorProperty); }
            set { SetValue(CustomBackgroundColorProperty, value); }
        }
    }
}