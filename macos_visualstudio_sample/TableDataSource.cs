using System;
using System.Collections.Generic;

using AppKit;
using Foundation;

namespace sample_TableView
{
    public class TableDataDelegate : NSTableViewDelegate
    {
        readonly string CellIdentifier = "Datas";
        private TableDataSource DataSource { get; set; }

        public TableDataDelegate(TableDataSource _DataSource)
        {
            this.DataSource = _DataSource;
        }
        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);

            if (view == null)
            {
                view = new NSTextField()
                {
                    Identifier = CellIdentifier,
                    BackgroundColor = NSColor.Clear,
                    Bordered = false,
                    Selectable = false,
                    Editable = false,
                };
            }
            try
            {
                int selectColumn = -1;
                for (int i = 0; i < tableView.ColumnCount; i++)
                {
                    var _tcolumn = tableView.TableColumns()[i];
                    if (_tcolumn == tableColumn)
                    {
                        Console.WriteLine($"{tableColumn} {tableView.TableColumns()[i]}");
                        selectColumn = i;
                        break;
                    }
                }
                view.StringValue = DataSource.Items[(int)row][selectColumn];
            }
            catch
            {
                view.StringValue = "";
            }
            return view;
        }
    }

    public class TableDataSource: NSTableViewDataSource
    {
        public List<List<string>> Items { get; set; }
        public TableDataSource()
        {
            Items = new List<List<string>>();
        }
        public override nint GetRowCount(NSTableView tableView)
        {
            return Items.Count;
        }
        public nint AddRows(List<string> _data)
        {
            Items.Add(_data);

            return Items.Count;
        }
    }
}
