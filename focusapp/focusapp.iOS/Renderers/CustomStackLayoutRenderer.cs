using CoreAnimation;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using focusapp.iOS.Renderers;
using System.Linq;

[assembly: ExportRenderer(typeof(StackLayout), typeof(CustomStackLayoutRenderer))]
 namespace focusapp.iOS.Renderers
{
    public class CustomStackLayoutRenderer : VisualElementRenderer<StackLayout>
    {
        #region ViewRenderer Overrides

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        /// <inheritdoc />
		public override void LayoutSubviews()
        {
            try
            {
                base.LayoutSubviews();
            }
            catch (MonoTouchException e)
            {
            }
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
                    if(subviewLength == subCount)
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
            maskLayer.LineWidth = 2;  //set the border width
            view.Layer.AddSublayer(maskLayer);
        }
        #endregion
    }
}