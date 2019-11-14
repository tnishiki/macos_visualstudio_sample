using System;
using AppKit;
using Foundation;
using ObjCRuntime;

namespace Browser
{
    public delegate void EVOutlineViewClicked(NSOutlineView outlineView, TreeDataItem item);

    public class OutlineViewDelegate : NSOutlineViewDelegate
    {
        private OutlineView _controller;
        public EVOutlineViewClicked EVOutlineViewClicked { get;set;} =null;

        public OutlineViewDelegate()
        {
        }
        public OutlineViewDelegate(OutlineView controller)
        {
            this._controller = controller;
        }

        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            NSTextField view = null;

            view = (NSTextField)outlineView.MakeView("TreeViewRoot", this);

            if (view == null)
            {
                view = new NSTextField();
                view.Identifier = "TreeViewRoot";
                view.BackgroundColor = NSColor.Clear;
                view.Bordered = false;
                view.Selectable = true;
                view.Editable = true;
                view.StringValue = ((TreeDataItem)item).Name;
            }
            else { 
                view.StringValue = ((TreeDataItem)item).Name;
            }

            return view;
        }
        public override void DidClickTableColumn(NSOutlineView outlineView, NSTableColumn tableColumn)
        {
            // click table header
        }
        [Export("outlineView:shouldSelectItem:")]
        public override bool ShouldSelectItem(NSOutlineView outlineView, NSObject item)
        {
            if (item is TreeDataItem)
            {
                EVOutlineViewClicked?.Invoke(outlineView,(TreeDataItem)item);
            }

            return true;
        }
    }
}
