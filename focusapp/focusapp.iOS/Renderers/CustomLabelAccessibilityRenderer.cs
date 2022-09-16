//using System;
//using System.ComponentModel;
//using focusapp.iOS.Renderers;
//using Foundation;
//using UIKit;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelAccessibilityRenderer))]
//namespace focusapp.iOS.Renderers
//{
//	[Preserve(AllMembers = true)]
//	public class CustomLabelAccessibilityRenderer : LabelRenderer
//	{
//		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
//		{

//			base.OnElementChanged(e);

//			if (Control == null)
//			{
//				return;
//			}

//			Console.WriteLine("created from IOS");
//		}

//		protected override UILabel CreateNativeControl()
//		{
//			return new AccessibleLabel();
//		}


//	}

//	public class AccessibleLabel : UILabel
//	{

//		public AccessibleLabel() : base()
//		{
//			Console.WriteLine($"***** AccessibleButton created *****");

//		}

//		public override void AccessibilityElementDidBecomeFocused()
//		{
//			base.AccessibilityElementDidBecomeFocused();
//			this.BackgroundColor = UIColor.Green;
//			Console.WriteLine("I am in focus");
//		}

//		public override void AccessibilityElementDidLoseFocus()
//		{
//			base.AccessibilityElementDidLoseFocus();
//			this.BackgroundColor = UIColor.White;
//			Console.WriteLine("I am NOT in focus");
//		}
//	}
//}