using System;
using focusapp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace focusapp.iOS.Renderers
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{

			base.OnElementChanged(e);

			if (Control == null)
			{
				return;
			}

			Console.WriteLine("created from IOS");
			Control.BackgroundColor = UIColor.Red;

		}

		protected override UIButton CreateNativeControl()
		{
			return new AccessibleButton();
		}


	}

	public class AccessibleButton : UIButton
	{

		public AccessibleButton() : base()
		{
			Console.WriteLine($"***** AccessibleButton created *****");

		}

		public override void AccessibilityElementDidBecomeFocused()
		{
			base.AccessibilityElementDidBecomeFocused();
			this.BackgroundColor = UIColor.Green;
			Console.WriteLine("I am in focus");
		}

		public override void AccessibilityElementDidLoseFocus()
		{
			base.AccessibilityElementDidLoseFocus();
			this.BackgroundColor = UIColor.Red;
			Console.WriteLine("I am NOT in focus");
		}
	}
}