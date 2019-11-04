using System;

using AppKit;
using WebKit;
using Foundation;

namespace sample_WebKit
{
    public partial class ViewController : NSViewController
    {
        private WebKitDelegate _webKitDelegate;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.

            _webKitDelegate = new WebKitDelegate()
            {
                DidFinishCallback = DidFinishNavigation,
            };
            WebKit.NavigationDelegate = _webKitDelegate;
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

        private string _AccessURL = "";
        [Export("AccessURL")]
        public string AccessURL {            get { return _AccessURL; }            set
            {
                WillChangeValue(nameof(AccessURL));
                _AccessURL = value;
                GetWebPage(_AccessURL);
                DidChangeValue(nameof(AccessURL));
            }
        }

        public void GetWebPage(string _url)
        {
            WebKit.LoadRequest(new NSUrlRequest(new NSUrl(_url)));
        }

        public void DidFinishNavigation()
        {
            WillChangeValue(nameof(AccessURL));
            _AccessURL = _webKitDelegate.CurrentUrl;
            DidChangeValue(nameof(AccessURL));
        }
    }
}
