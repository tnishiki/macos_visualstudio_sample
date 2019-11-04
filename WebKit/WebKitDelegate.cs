using System;
using AppKit;
using WebKit;

namespace sample_WebKit
{
    public delegate void FncDidFinishCallback();

    public class WebKitDelegate: WKNavigationDelegate
    {
        public string CurrentUrl = "";
        public FncDidFinishCallback DidFinishCallback=null;

        public WebKitDelegate()
        {
        }

        public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            CurrentUrl = webView.Url.ToString();

            if (DidFinishCallback != null)
            {
                DidFinishCallback();
            }
        }
    }
}
