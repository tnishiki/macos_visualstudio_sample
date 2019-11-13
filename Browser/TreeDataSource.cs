using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace Browser
{
    public class TreeDataSource: NSOutlineViewDataSource
    {
        private OutlineView _controller;

        public List<TreeDataItem> Items = new List<TreeDataItem>();

        public TreeDataSource()
        {
        }

        public TreeDataSource(OutlineView controller)
        {
            // Initialize
            this._controller = controller;
        }

        public override nint GetChildrenCount(NSOutlineView outlineView, Foundation.NSObject item)
        {
            if (item == null)
            {
                return Items.Count;
            }
            else
            {
                return ((TreeDataItem)item).Count;
            }
        }

        public override bool ItemExpandable(NSOutlineView outlineView, Foundation.NSObject item)
        {
            return ((TreeDataItem)item).HasChildren;
        }

        public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, Foundation.NSObject item)
        {
            if (item == null)
            {
                return Items[(int)childIndex];
            }
            else
            {
                return ((TreeDataItem)item)[(int)childIndex];
            }
        }
    }
}
