using Foundation;
using System;
using UIKit;
using PCLItems.Core.Service;
using EmPrep.DataSource;
using PCLItems.Core.Repository;

namespace EmPrep
{
    public partial class FirstTabBarController : UITableViewController
    {
        public FirstTabBarController (IntPtr handle) : base (handle)
        {
        }

        //NamesDataService dataService = new NamesDataService();
        RestDataService dataService = new RestDataService(new ShelterRestService());

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			var names = dataService.GetTasksAsync();
            names.Wait();
			var datasource = new DataSource.NamesDataSource(names.Result, this);


			TableView.Source = datasource;
			TableView.UserInteractionEnabled = true;

			this.NavigationItem.Title = "Shelters";
		}

		//using Segues
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			if (segue.Identifier == "FavoriteSegue")
			{
				var namesDetailController = segue.DestinationViewController as DetailViewController;
				if (namesDetailController != null)
				{
					var source = TableView.Source as NamesDataSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					namesDetailController.selectedModel = item;
				}
			}
		}
    }
}