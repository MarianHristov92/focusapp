using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using focusapp.iOS.Focus;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ResolutionGroupName ("FocusApp")]
[assembly:ExportEffect (typeof(FocusEffect), nameof(FocusEffect))]
namespace focusapp.iOS.Focus
{
    public class FocusEffect : PlatformEffect
    {
        UIView view;
        float width,height;
        public Func<Brush, CALayer> OriginalBackground { get; private set; }

        protected override void OnAttached()
        {
        }

        private void CreateRectange()
        {
            height = (float)Control.Frame.Height;
            width = (float)Control.Frame.Width;
            view = new UIView();
            view.BackgroundColor = UIColor.Clear;
            view.Frame = new CGRect(0,0,width,height);
            var maskLayer = new CAShapeLayer();
            UIBezierPath bezierPath = UIBezierPath.FromRoundedRect(view.Bounds, (UIRectCorner.TopLeft | UIRectCorner.BottomLeft), new CGSize(0,0));
            maskLayer.Path = bezierPath.CGPath;
            maskLayer.Frame = view.Bounds;
            maskLayer.StrokeColor = UIColor.Red.CGColor; //set the borderColor
            maskLayer.FillColor = UIColor.Clear.CGColor;  //set the background color
            maskLayer.LineWidth = 1;  //set the border width
            view.Layer.AddSublayer(maskLayer);
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);   
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    CreateRectange();
                    Control.AddSubview(view);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }
    }
}
