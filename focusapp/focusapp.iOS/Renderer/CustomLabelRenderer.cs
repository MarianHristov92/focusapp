using System.ComponentModel;
using focusapp.iOS.Renderer;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace focusapp.iOS.Renderer
{
    [Preserve(AllMembers = true)]
	public class CustomLabelRenderer : LabelRenderer
	{
		#region ViewRenderer Overrides
		UIColor originalColor;

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
				originalColor = Control.BackgroundColor;
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
		}

		public override bool CanBecomeFocused => true;

		public override void DidUpdateFocus(UIFocusUpdateContext context, UIFocusAnimationCoordinator coordinator)
		{
			base.DidUpdateFocus(context, coordinator);
			if (Control.BackgroundColor == originalColor)
				Control.BackgroundColor = UIColor.Red;
			else
				Control.BackgroundColor = originalColor;
		}
		#endregion
	}
}