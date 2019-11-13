using System;
using System.Collections;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace Browser
{
    public class TreeDataItem : NSObject, IEnumerator, IEnumerable
    {
        private string _Name { get; set; }
        private TreeDataItem _Parent { get; set; } = null;
        private List<TreeDataItem> _Items { get; set; } = new List<TreeDataItem>();

        public delegate void ClickedDelegate();
        public event ClickedDelegate Clicked;
        internal void RaiseClickedEvent()
        {
            if (this.Clicked != null)
                this.Clicked();
        }

        private int _position = -1;

        public TreeDataItem()
        {
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public TreeDataItem this[int index]
        {
            get { return _Items[index]; }
            set { _Items[index] = value; }
        }

        public int Count
        {
            get { return _Items.Count; }
        }
        public bool HasChildren
        {
            get{ return (Count > 0); }
        }

        #region Iterator method
        public IEnumerator GetEnumerator()
        {
            _position = -1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            _position++;
            return (_position < _Items.Count);
        }
        public void Reset()
        {
            _position = -1;
        }
        public object Current
        {
            get
            {
                try
                {
                    return _Items[_position];
                }
                catch
                {
                    throw new InvalidOperationException();
                }
            }
        }
        #endregion

        #region constractor
        public TreeDataItem(string _name)
        {
            this._Name = _name;
        }
        public TreeDataItem(string _name , ClickedDelegate _clicked)
        {
            this._Name = _name;
            this.Clicked = _clicked;
        }
        #endregion

        #region AddItem
        public void AddItem(TreeDataItem _data)
        {
            _Items.Add(_data);
        }
        public void AddItem(string _name)
        {
            _Items.Add(new TreeDataItem(_name));
        }
        public void AddItem(string _name, ClickedDelegate clicked)
        {
            _Items.Add(new TreeDataItem(_name, clicked));
        }
        #endregion

        #region Insert
        public void Insert(int n, TreeDataItem _item)
        {
            _Items.Insert(n, _item);
        }
        #endregion

        #region RemoveItem
        public void RemoveItem(TreeDataItem item)
        {
            _Items.Remove(item);
        }
        public void RemoveItem(int n)
        {
            _Items.RemoveAt(n);
        }
        #endregion

        public void Clear()
        {
            _Items.Clear();
        }
    }
}
