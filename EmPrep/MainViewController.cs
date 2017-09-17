using Foundation;
using System;
using UIKit;

namespace EmPrep
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.AddSubview(new UIImageView(UIImage.FromFile(@"Images/background.png")));
        }
    }
}