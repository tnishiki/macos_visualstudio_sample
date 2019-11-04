using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace macos_visualstudio_sample
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
            TableDataSource DataSource = new TableDataSource();
            ImportData(DataSource);

            GridView.DataSource = DataSource;
            GridView.Delegate = new TableDataDelegate(DataSource);

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
                // Update the view, if already loaded.
            }
        }
        public void ImportData(TableDataSource _datasource)
        {
            string[] h = { "header1", "header2" };
            SetHeader(h);

            var lines = new List<List<string>>();
            lines.Add(new List<string>() { "data1", "subdata1" });
            lines.Add(new List<string>() { "data2", "subdata2" });
            lines.Add(new List<string>() { "data3", "subdata3" });

            foreach (var l in lines)
            {
                _datasource.AddRows(l);
            }
        }

        public void SetHeader(string[] _header)
        {
            //clear all header
            for (int i = 0; i < GridView.ColumnCount; i++)
            {
                GridView.RemoveColumn(GridView.TableColumns()[i]);
            }

            //import headers
            foreach (var h in _header)
            {
                GridView.AddColumn(new NSTableColumn() { Title = h });
            }
        }
    }
}