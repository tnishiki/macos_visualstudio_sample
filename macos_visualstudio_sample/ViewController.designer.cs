// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace macos_visualstudio_sample
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTableView GridView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (GridView != null) {
				GridView.Dispose ();
				GridView = null;
			}
		}
	}
}