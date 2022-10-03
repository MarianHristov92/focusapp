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
        UIColor backgroundColor;
        UIView view;

        public Func<Brush, CALayer> OriginalBackground { get; private set; }

        protected override void OnAttached()
        {
            try
            {
                OriginalBackground = Container.GetBackgroundLayer;
                if (Control != null)
                {
                    //this.Control.DidUpdateFocus(context:Control, )
                    CreateRectange();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        private void CreateRectange()
        {
            view = new UIView();
            view.BackgroundColor = UIColor.Clear;
            view.Frame = new CGRect(30, 100, 36, 36);
            var maskLayer = new CAShapeLayer();

            UIBezierPath bezierPath = UIBezierPath.FromRoundedRect(view.Bounds, (UIRectCorner.TopLeft | UIRectCorner.BottomLeft), new CGSize(18.0, 18.0));


            maskLayer.Path = bezierPath.CGPath;
            maskLayer.Frame = view.Bounds;

            maskLayer.StrokeColor = UIColor.Black.CGColor; //set the borderColor
            maskLayer.FillColor = UIColor.Red.CGColor;   //set the background color
            maskLayer.LineWidth = 1;  //set the border width

            view.Layer.AddSublayer(maskLayer);

            Container.AddSubview(view);
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
