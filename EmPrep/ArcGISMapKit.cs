using System;
using UIKit;
using Foundation;
using Esri.ArcGISRuntime.UI.Controls;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.UI;
using MapKit;
using PCLItems.Core.Repository;
using CoreLocation;

namespace EmPrep
{
    public partial class ArcGISMapKit : UIViewController
    {
        public ArcGISMapKit(IntPtr handle) : base(handle)
        {
        }

        // Create and hold reference to the used MapView
        private MapView _myMapView = new MapView();

        public ArcGISMapKit()
        {
            Title = "Display Device Location";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Create the UI, setup the control references and execute initialization 
            Initialize();
            CreateLayout();

        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NavigationController.ToolbarHidden = true;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            // Setup the visual frame for the MapView
            _myMapView.Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
        }

        private void Initialize()
        {
            // Create new Map with basemap
            Map myMap = new Map(Basemap.CreateImagery());

            // Provide used Map to the MapView
            _myMapView.Map = myMap;
        }

        private void OnStopButtonClicked(object sender, EventArgs e)
        {
            //TODO Remove this IsStarted check https://github.com/Esri/arcgis-runtime-samples-xamarin/issues/182
            if (_myMapView.LocationDisplay.IsEnabled)
                _myMapView.LocationDisplay.IsEnabled = false;
        }

        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            try
            {
                UIAlertController actionAlert = UIAlertController.Create(
                    "Select device location option", "", UIAlertControllerStyle.Alert);

                // Add actions to alert. Selecting an option displays different option for auto pan modes.
                actionAlert.AddAction(UIAlertAction.Create("On", UIAlertActionStyle.Default, (action) =>
                {
                    // Starts location display with auto pan mode set to Off
                    _myMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Off;

                    //TODO Remove this IsStarted check https://github.com/Esri/arcgis-runtime-samples-xamarin/issues/182
                    if (!_myMapView.LocationDisplay.IsEnabled)
                        _myMapView.LocationDisplay.IsEnabled = true;
                }));
                actionAlert.AddAction(UIAlertAction.Create("Re-center", UIAlertActionStyle.Default, (action) =>
                {

                }));
                actionAlert.AddAction(UIAlertAction.Create("Navigation", UIAlertActionStyle.Default, (action) =>
                {
                    // Starts location display with auto pan mode set to Navigation
                    _myMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Navigation;

                    //TODO Remove this IsStarted check https://github.com/Esri/arcgis-runtime-samples-xamarin/issues/182
                    if (!_myMapView.LocationDisplay.IsEnabled)
                        _myMapView.LocationDisplay.IsEnabled = true;
                }));
                actionAlert.AddAction(UIAlertAction.Create("Compass", UIAlertActionStyle.Default, (action) =>
                {
                    // Starts location display with auto pan mode set to Compass Navigation
                    _myMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.CompassNavigation;

                    //TODO Remove this IsStarted check https://github.com/Esri/arcgis-runtime-samples-xamarin/issues/182
                    if (!_myMapView.LocationDisplay.IsEnabled)
                        _myMapView.LocationDisplay.IsEnabled = true;
                }));
                //present alert
                PresentViewController(actionAlert, true, null);
            }
            catch (Exception ex)
            {
                UIAlertController alert = UIAlertController.Create("Error", ex.Message, UIAlertControllerStyle.Alert);
                PresentViewController(alert, true, null);
            }
        }

        private void CreateLayout()
        {
            // Create a button to start the location
            var startButton = new UIBarButtonItem() { Title = "Back", Style = UIBarButtonItemStyle.Plain };
            startButton.Clicked += OnStartButtonClicked;



            // Add the buttons to the toolbar
            SetToolbarItems(new UIBarButtonItem[] {startButton,
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace, null)}, false);

            // Show the toolbar
            NavigationController.ToolbarHidden = false;

            // Add MapView to the page
            View.AddSubviews(_myMapView);

            // Starts location display with auto pan mode set to Default
            _myMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Recenter;

            //TODO Remove this IsStarted check https://github.com/Esri/arcgis-runtime-samples-xamarin/issues/182
            if (!_myMapView.LocationDisplay.IsEnabled)
                _myMapView.LocationDisplay.IsEnabled = true;
        }
    }

    public class EsriMapDelegate : MKMapViewDelegate
    {
        protected string annotationIdentifier = "BasicAnnotation";
        UIButton detailButton;
        MapKitViewController parent;

        public static int color = 1;
        public EsriMapDelegate(MapKitViewController parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// This is very much like the GetCell method on the table delegate
        /// </summary>
        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            // try and dequeue the annotation view
            MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);
            // if we couldn't dequeue one, create a new one
            if (annotationView == null)
                annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
            else // if we did dequeue one for reuse, assign the annotation to it
                annotationView.Annotation = annotation;
            // configure our annotation view properties
            annotationView.CanShowCallout = true;
            (annotationView as MKPinAnnotationView).AnimatesDrop = true;
            if (color == 1)
            {
                (annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Green;
            }
            else if (color == 2)
            {
                (annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Red;
            }
            else
            {
                (annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Purple;
            }
            annotationView.Selected = true;
            // you can add an accessory view, in this case, we'll add a button on the right, and an image on the left
            detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);
            detailButton.TouchUpInside += (s, e) =>
            {
                Console.WriteLine("Clicked");
                //Create Alert
                var detailAlert = UIAlertController.Create("Binduraj Chandrasekaran", "415 516 1334", UIAlertControllerStyle.Alert);

                detailAlert.AddAction(UIAlertAction.Create("REQUEST HELP", UIAlertActionStyle.Default, (action) =>
                {
                    NexmoDataService nexmo = new NexmoDataService();
                    nexmo.VoiceCall("19256993334", "12016728509");
                }));

                detailAlert.AddAction(UIAlertAction.Create("CALL", UIAlertActionStyle.Default, (action) =>
                {
                    NexmoDataService nexmo = new NexmoDataService();
                    nexmo.VoiceCall("19256993334", "12016728509");
                }));
                detailAlert.AddAction(UIAlertAction.Create("SMS", UIAlertActionStyle.Default, (action) =>
                {
                    NexmoDataService nexmo = new NexmoDataService();
                    nexmo.SMS("19256993334", "12016728509");
                }));
                detailAlert.AddAction(UIAlertAction.Create("CANCEL", UIAlertActionStyle.Cancel, null));
                parent.PresentViewController(detailAlert, true, null);
            };
            annotationView.RightCalloutAccessoryView = detailButton;
            annotationView.LeftCalloutAccessoryView = new UIImageView(UIImage.FromBundle("firstresponder.png"));
            return annotationView;
        }

        // as an optimization, you should override this method to add or remove annotations as the
        // map zooms in or out.
        public override void RegionChanged(MKMapView mapView, bool animated) { }

  
    }

}