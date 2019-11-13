using System;
using AppKit;
using Foundation;

namespace Browser
{
    [Register("OutlineView")]
    public class OutlineView: NSOutlineView
    {
        public TreeDataSource Data
        {
            get { return (TreeDataSource)this.DataSource; }
        }

        public OutlineView()
        {
        }
        public OutlineView(IntPtr handle) : base(handle)
        {
        }
        public OutlineView(NSCoder coder) : base(coder)
        {
        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
        public void Initialize()
        {
            this.DataSource = new TreeDataSource(this);
            this.Delegate = new OutlineViewDelegate(this);
        }
        public void AddItem(TreeDataItem item)
        {
            if (Data != null)
            {
                Data.Items.Add(item);
            }
        }
    }
}
