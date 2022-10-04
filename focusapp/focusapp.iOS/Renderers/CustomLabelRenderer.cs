using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using focusapp.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace focusapp.iOS.Renderers
{
    [Preserve(AllMembers = true)]
    public class CustomLabelRenderer : LabelRenderer
    {
        UIView view;
        float width, height;
        public Func<Brush, CALayer> OriginalBackground { get; private set; }

        UIColor originalColor;
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                originalColor = Control.BackgroundColor;
        }

        public override bool CanBecomeFocused => true;

        public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
        {
            base.DidUpdateFocus(context, coordinator);
            if (Control.Subviews.Length == 0)
            {
                CreateRectange();
                Control.AddSubview(view);
            }
            else
            {
                foreach (var sub in Control.Subviews)
                {
                    sub.RemoveFromSuperview();
                }
            } 
        }

        private void CreateRectange()
        {
            height = (float)Control.Frame.Height;
            width = (float)Control.Frame.Width;
            view = new UIView();
            view.BackgroundColor = UIColor.Clear;
            view.Frame = new CGRect(0, 0, width, height);
            var maskLayer = new CAShapeLayer();
            UIBezierPath bezierPath = UIBezierPath.FromRoundedRect(view.Bounds, (UIRectCorner.TopLeft | UIRectCorner.TopRight | UIRectCorner.BottomLeft | UIRectCorner.BottomRight), new CGSize(7, 7));
            maskLayer.Path = bezierPath.CGPath;
            maskLayer.Frame = view.Bounds;
            maskLayer.StrokeColor = UIColor.FromRGB(0, 97, 160).CGColor; //set the borderColor
            maskLayer.FillColor = UIColor.Clear.CGColor;  //set the background color
            maskLayer.LineWidth = 2;  //set the border width
            view.Layer.AddSublayer(maskLayer);
        }
    }
}