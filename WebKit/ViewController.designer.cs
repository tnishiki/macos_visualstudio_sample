// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WebKit
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField TextFieldURL { get; set; }

		[Outlet]
		WebKit.WKWebView WebKit { get; set; }

		[Action ("TextFieldAction:")]
		partial void TextFieldAction (AppKit.NSTextField sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TextFieldURL != null) {
				TextFieldURL.Dispose ();
				TextFieldURL = null;
			}

			if (WebKit != null) {
				WebKit.Dispose ();
				WebKit = null;
			}
		}
	}
}
