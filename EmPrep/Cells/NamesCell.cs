using System;
using System.Drawing;
using Foundation;
using UIKit;

namespace EmPrep.Cells
{
    public class NamesCell : UITableViewCell
    {
        UILabel nameLabel;
        UILabel priceLabel;
        UIImageView imageView;

        public NamesCell()
        {
        }

        public NamesCell (NSString cellId) : base (UITableViewCellStyle.Default,cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Blue;
            ContentView.BackgroundColor = UIColor.FromRGB(203, 221, 244);
            imageView = new UIImageView();

            nameLabel = new UILabel()
            {
                Font = UIFont.FromName("Cochin-BoldItalic", 24f),
                TextColor = UIColor.Black,
                BackgroundColor = UIColor.Clear
            };

            priceLabel = new UILabel()
            {
                Font = UIFont.FromName("AmericanTypeWriter", 18f),
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };

            ContentView.Add( nameLabel);
            ContentView.Add(priceLabel);
            ContentView.Add(imageView);

        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            imageView.Frame = new RectangleF((float)3,5,33,33);
            nameLabel.Frame = new RectangleF(155, 5, 133,133);
            //priceLabel.Frame = new RectangleF(0, 0, 0, 0);

        }



        public void UpdateCell(string caption, string subtitle,UIImage image)
        {
            imageView.Image = image;
            nameLabel.Text = caption;
            priceLabel.Text = subtitle;
        }

    }
}
