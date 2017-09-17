using Foundation;
using System;
using UIKit;
using PCLItems.Core.Model;
using PCLItems.Core.Service;

namespace EmPrep
{
    public partial class DetailViewController : UIViewController
    {

        public ServiceModel selectedModel { get; set; }
        public DetailViewController (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            DataBindUI();

            btnAddToCart.TouchUpInside += (sender, e) => {
                //UIAlertView message = new UIAlertView("Title", "Added");
                this.DismissViewController(true,null);
            };

            btnCancel.TouchUpInside += (sender, e) => {
                //Code goes here
                this.DismissViewController(true, null);
            };
        }

        private void DataBindUI()
        {
            UIImage img = UIImage.FromFile("Images/Image" 
                                           + selectedModel.userId + ".jpg");
            imgImage.Image = img;
            lblName.Text = selectedModel.title;
            lblPrice.Text = selectedModel.userId.ToString();
            lblShortDescription.Text = selectedModel.body;
            //lblLongdescription.Text = selectedName.Description;

        }
    }
}