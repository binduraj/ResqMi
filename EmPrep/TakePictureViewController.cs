using Foundation;
using System;
using UIKit;
using Xamarin.Media;
using System.Threading.Tasks;

namespace EmPrep
{
    public partial class TakePictureViewController : UIViewController
    {
        private MediaPicker mediaPicker = new MediaPicker();
        private TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        private UIAlertView alterView;
        private MediaPickerController mediaPickerController;
        public TakePictureViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            btnTakePicture.TouchUpInside += (object sender, EventArgs e) => 
            {
                if (!mediaPicker.IsCameraAvailable)
                {
                    alterView = new UIAlertView("Title", "No Camera", new UIAlertViewDelegate(),"OK");
                    alterView.Show();
                    return;
                }

                //mediaPicker.GetPickPhotoUI();
                //mediapicker.getvideo etc
                mediaPickerController = mediaPicker.GetTakePhotoUI(
                    new StoreCameraMediaOptions
                {
                    Name = "myselfie.jpg",
                    Directory = "MySelfies"
                }
                );

                PresentViewController(mediaPickerController,true,null);
                mediaPickerController.GetResultAsync().ContinueWith(t =>{
                    selfieImage.Image = UIImage.FromFile(t.Result.Path);
                    DismissViewController(true,null);
                }, uiScheduler);
            };
        }
    }
}