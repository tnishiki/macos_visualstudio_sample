using System;

using AppKit;
using Foundation;

namespace Browser
{
    public class BrowserDelegate: NSBrowserDelegate
    {
        public BrowserDelegate()
        {
        }

        [Export("browser:numberOfRowsInColumn:")]
        public override nint RowsInColumn(NSBrowser sender, nint column)
        {
            return 10;
        }

        [Export("browser:willDisplayCell:atRow:column:")]
        public override void WillDisplayCell(NSBrowser sender, NSObject cell, nint row, nint column)
        {
            NSBrowserCell c = cell as NSBrowserCell;
            c.Title = $"aaa{row} - {column}";
            //Leaf
            // true  ... terminated
            // false ... right below
            c.Leaf = false;
        }
    }
}
