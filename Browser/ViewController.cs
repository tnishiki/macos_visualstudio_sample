using System;

using AppKit;
using CoreData;
using Foundation;

namespace Browser
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.

            Browser.Delegate = new BrowserDelegate();
            Browser.MaxVisibleColumns = 2;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            OutlineView.Initialize();

            {
                var TableViews = new TreeDataItem("Vegetables");
                TableViews.AddItem(new TreeDataItem("Cabbage"));
                TableViews.AddItem(new TreeDataItem("Turnip"));
                TableViews.AddItem(new TreeDataItem("Radish"));
                TableViews.AddItem(new TreeDataItem("Carrot"));
                OutlineView.AddItem(TableViews);
            }
            {
                var TableViews = new TreeDataItem("Fruits");
                TableViews.AddItem(new TreeDataItem("Grape"));
                TableViews.AddItem(new TreeDataItem("Cucumber"));
                OutlineView.AddItem(TableViews);
            }

            OutlineView.ReloadData();
            OutlineView.ExpandItem(null, true);
        }
    }
}