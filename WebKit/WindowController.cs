using System;
using AppKit;
using Foundation;

namespace sample_WebKit
{
    [Register("WindowController")]
    public class WindowController: NSWindowController
    {
        public WindowController(IntPtr handle):base(handle)
        {
        }

        [Action("newDocument:")]
        public void newDocument(NSObject sender)
        {
            // Get new window
            try
            {
                var storyboard = NSStoryboard.FromName("Main", null);
                var controller = storyboard.InstantiateControllerWithIdentifier("MainWindow") as NSWindowController;
                // Display
                controller.ShowWindow(this);
            }
            catch
            {
                //
            }

        }
    }
}
