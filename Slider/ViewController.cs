using System;

using AppKit;
using Foundation;

namespace Slider
{
    public delegate void FncChangeCircularSliderValue();

    public partial class ViewController : NSViewController
    {
        public FncChangeCircularSliderValue ChangedCircularSliderValueCallback = null;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.

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

        private Double _CircularSliderValue;
        [Export("CircularSliderValue")]
        public Double CircularSliderValue
        {            get { return _CircularSliderValue; }            set
            {
                WillChangeValue(nameof(CircularSliderValue));
                _CircularSliderValue = value;
                if (ChangedCircularSliderValueCallback != null)
                {
                    ChangedCircularSliderValueCallback();
                }
                DidChangeValue(nameof(CircularSliderValue));
            }
        }

        partial void CircularSliderAction(Foundation.NSObject sender)
        {
            LevelIndicator.DoubleValue = CircularSlider.DoubleValue;
        }
    }
}
