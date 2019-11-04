// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Slider
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSSlider CircularSlider { get; set; }

		[Outlet]
		AppKit.NSLevelIndicator LevelIndicator { get; set; }

		[Action ("CircularSliderAction:")]
		partial void CircularSliderAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (CircularSlider != null) {
				CircularSlider.Dispose ();
				CircularSlider = null;
			}

			if (LevelIndicator != null) {
				LevelIndicator.Dispose ();
				LevelIndicator = null;
			}
		}
	}
}
