using Foundation;
using System;
using UIKit;
using PCLItems.Core.Service;
using EmPrep.DataSource;
using PCLItems.Core.Model;

namespace EmPrep
{
    public partial class NamesTableViewController : UITableViewController
    {

        NamesDataService dataService = new NamesDataService();

        public NamesTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //var names = dataService.();
            //var datasource = new DataSource.NamesDataSource(names, this);

            //TableView.Source = datasource;
            //TableView.UserInteractionEnabled = true;

            //this.NavigationItem.Title = "Names Table View Title";
        }

        //using Segues
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			//base.PrepareForSegue(segue, sender);
			//if (segue.Identifier == "NamesDetailSegue")
			//{
			//	var namesDetailController = segue.DestinationViewController as DetailViewController;
			//	if (namesDetailController != null)
			//	{
			//		var source = TableView.Source as NamesDataSource;
			//		var rowPath = TableView.IndexPathForSelectedRow;
			//		var item = source.GetItem(rowPath.Row);
			//		namesDetailController.selectedName = item;
			//	}
			//}
		}

        //using custom method - PArtial Curl (Remove Segues on the story board)
        //public async void NamesSelected(Names selectedName)
        //{
        //    DetailViewController namesDetailViewController =
        //        this.Storyboard.InstantiateInitialViewController() as DetailViewController;

        //    if (namesDetailViewController != null)
        //    {
        //        namesDetailViewController.ModalTransitionStyle = UIModalTransitionStyle.PartialCurl;
        //        namesDetailViewController.selectedName = selectedName;
        //        await PresentViewControllerAsync(namesDetailViewController, true);
        //    }
        //}
 
    }
}