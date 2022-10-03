using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using focusapp.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace focusapp.iOS.Renderers
{
	[Preserve(AllMembers = true)]
	public class CustomButtonRenderer : ButtonRenderer
	{
		private IElementController ElementController => Element as IElementController;
		private Button button;

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			button = e.NewElement;


		}

		
		private void OnFocused(object sender, EventArgs e)
		{
			ElementController.SetValueFromRenderer(Button.IsFocusedPropertyKey, true);
			
			// Need to connect to Sizechanged event because first render time, Entry has no size (-1).
			if (button != null)
				button.SizeChanged += (obj, args) =>
				{
					var xamEl = obj as Button;
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