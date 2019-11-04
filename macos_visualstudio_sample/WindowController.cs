using AppKit;
using Foundation;
using System;

namespace macos_visualstudio_sample
{
    [Register("WindowController")]
    public class WindowController : NSWindowController
    {
        public WindowController(IntPtr handle) :base(handle)
        {
        }

        [Action("newDocument:")]
        public void newDocument(NSObject sender)
        {
            // Get new window
            var storyboard = NSStoryboard.FromName("Main", null);
            var controller = storyboard.InstantiateControllerWithIdentifier("MainWindow") as NSWindowController;

            // Display
            controller.ShowWindow(this);
        }
    }
}
