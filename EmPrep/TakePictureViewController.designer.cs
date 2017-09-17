// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace EmPrep
{
    [Register ("TakePictureViewController")]
    partial class TakePictureViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnTakePicture { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView selfieImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnTakePicture != null) {
                btnTakePicture.Dispose ();
                btnTakePicture = null;
            }

            if (selfieImage != null) {
                selfieImage.Dispose ();
                selfieImage = null;
            }
        }
    }
}