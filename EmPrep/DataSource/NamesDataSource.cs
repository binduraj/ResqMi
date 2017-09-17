using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using PCLItems.Core.Model;
using EmPrep.Cells;
using System.Linq;

namespace EmPrep.DataSource
{
    public class NamesDataSource : UIKit.UITableViewSource
    {
        private List<ServiceModel> namesList;

        NSString cellIdentifier = new NSString("NamesCell");

        UITableViewController sourceController;
        public NamesDataSource(List<ServiceModel> names, UITableViewController callingController)
        {
            this.namesList = names;
            this.sourceController = callingController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            /* UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;
             if (cell == null)
             {
                 cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
             }

             var name = namesList[indexPath.Row];
             cell.TextLabel.Text = name.Name;
             cell.ImageView.Image = UIImage.FromFile("Images/Image" + name.Id + ".jpg");
             
            */
           NamesCell cell = tableView.DequeueReusableCell(cellIdentifier) as NamesCell;
            if (cell == null)
            {
                cell = new NamesCell(cellIdentifier);
            }

            cell.UserInteractionEnabled = true;
            cell.UpdateCell(namesList[indexPath.Row].userId,
                           namesList[indexPath.Row].title.ToString(),
                           UIImage.FromFile("Images/shelter" + ".png"));

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return namesList.Count;
        }

        public ServiceModel GetItem(int id)
        {
            return namesList[id];
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //using Segues
            sourceController.PerformSegue("FavoriteSegue",sourceController);

            ////Using Custom
            //var selectedName = namesList[indexPath.Row];
            //sourceController.NamesSelected(selectedName);
            //tableView.DeselectRow(indexPath,true);
        }


    }
}
