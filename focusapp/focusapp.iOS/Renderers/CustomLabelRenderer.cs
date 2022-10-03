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
        private IElementController ElementController => Element as IElementController;
        private Label label;

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            label = e.NewElement;

        }

        private void OnFocused(object sender, EventArgs e)
        {
            ElementController.SetValueFromRenderer(Label.IsFocusedPropertyKey, true);

            // Need to connect to Sizechanged event because first render time, Entry has no size (-1).
            if (label != null)
                label.SizeChanged += (obj, args) =>
                {
                    var xamEl = obj as Label;
                    if (xamEl == null)
                        return;

                    // get native control (UITextField)
                    var entry = this.Control;

                    // Create borders (bottom only)
                    CALayer border = new CALayer();
                    float width = 1.0f;
                    border.BorderColor = new CoreGraphics.CGColor(0.73f, 0.7451f, 0.7647f);  // gray border color
                    border.Frame = new CGRect(x: 0, y: xamEl.Height - width, width: xamEl.Width, height: 1.0f);
                    border.BorderWidth = width;

                    entry.Layer.AddSublayer(border);

                    entry.Layer.MasksToBounds = true;
                    //entry.BorderStyle = UITextBorderStyle.None;
                    entry.BackgroundColor = new UIColor(1, 1, 1, 1); // white
                };
        }
    }

}