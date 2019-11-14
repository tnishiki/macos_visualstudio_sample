// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Browser
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSBrowser Browser { get; set; }

		[Outlet]
		Browser.OutlineView OutlineView { get; set; }

		[Outlet]
		AppKit.NSTextField SelectItemName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Browser != null) {
				Browser.Dispose ();
				Browser = null;
			}

			if (OutlineView != null) {
				OutlineView.Dispose ();
				OutlineView = null;
			}

			if (SelectItemName != null) {
				SelectItemName.Dispose ();
				SelectItemName = null;
			}
		}
	}
}
