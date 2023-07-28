using CoreAnimation;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using focusapp.iOS.Renderers;

[assembly: ExportRenderer(typeof(Grid), typeof(CustomGridRenderer))]
 namespace focusapp.iOS.Renderers
{
    public class CustomGridRenderer : VisualElementRenderer<Grid>
    {
        #region ViewRenderer Overrides

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<Grid> e)
        {
            base.OnElementChanged(e);
        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
        #endregion

        #region Keyboard accessibility methods and overrides
        UIView view;
        float width, height;
        bool hasAddedFrame;

        public override bool CanBecomeFocused => true;

        public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
        {
            base.DidUpdateFocus(context, coordinator);
            if (!hasAddedFrame)
            {
                CreateRectange();
                AddSubview(view);
                hasAddedFrame = true;
            }
            else
            {
                hasAddedFrame = false;

                var subviewLength = Subviews.Length;
                int subCount = 0;
                foreach (var sub in Subviews)
                {
                    subCount++;
                    if (subviewLength == subCount)
                    {
                        sub.RemoveFromSuperview();
                    }
                }
            }
        }

        private void CreateRectange()
        {
            height = (float)Frame.Height;
            width = (float)Frame.Width;
            view = new UIView();
            view.BackgroundColor = UIColor.Clear;
            view.Frame = new CGRect(0, 0, width, height);
            var maskLayer = new CAShapeLayer();
            UIBezierPath bezierPath = UIBezierPath.FromRoundedRect(view.Bounds, (UIRectCorner.TopLeft | UIRectCorner.TopRight | UIRectCorner.BottomLeft | UIRectCorner.BottomRight), new CGSize(7, 7));
            maskLayer.Path = bezierPath.CGPath;
            maskLayer.Frame = view.Bounds;
            maskLayer.StrokeColor = UIColor.FromRGB(0, 97, 160).CGColor; //set the borderColor
            maskLayer.FillColor = UIColor.Clear.CGColor;  //set the background color
            maskLayer.LineWidth = 3;  //set the border width
            view.Layer.AddSublayer(maskLayer);
        }
        #endregion
    }
}