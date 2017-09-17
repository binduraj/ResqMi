using Foundation;
using System;
using UIKit;
using MapKit;
using CoreLocation;
using CoreGraphics;
using PCLItems.Core.Repository;
using PCLItems.Core.Service;

namespace EmPrep
{
    public partial class MapKitViewController2 : UIViewController
    {
        public MapKitViewController2 (IntPtr handle) : base (handle)
        {
        }

		private MKMapView mapView;
		private CLLocationManager locationManager = new CLLocationManager();



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Victims";


			mapView = new MKMapView(View.Bounds);
			mapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			mapView.MapType = MKMapType.Hybrid;
			View.AddSubview(mapView);
			locationManager.RequestWhenInUseAuthorization();

			if (CLLocationManager.LocationServicesEnabled)
			{
				mapView.ShowsUserLocation = true;

				locationManager.StartMonitoringSignificantLocationChanges();
				locationManager.StartUpdatingLocation();

			}

			MapDelegate1.color = 2;

			// create our location and zoom for los angeles
			var rcoords = new CLLocationCoordinate2D(37.774628, -122.387341); // paris
			var span = new MKCoordinateSpan(MilesToLatitudeDegrees(0.7), MilesToLongitudeDegrees(0.7, rcoords.Latitude));

			// set the coords and zoom on the map
			mapView.Region = new MKCoordinateRegion(rcoords, span);



			PersonDataService persons = new PersonDataService();
			foreach (var person in persons.GetAllPerson())
			{
				mapView.AddAnnotation(new MKPointAnnotation()
				{
					Title = person.Name,
					Subtitle = person.PhoneNumber + " - Help Me",
					Coordinate = new CLLocationCoordinate2D(person.latitude, person.longitude)
				});
			}


			// assign the delegate, which handles annotation layout and clicking
			mapView.Delegate = new MapDelegate2(this);




			// add a basic annotation
			var annotation = new BasicMapAnnotation(new CLLocationCoordinate2D(37.774628, -122.387341), "Sathish Kumar Natarajan", "415 533 1764");
			mapView.AddAnnotation(annotation);

			btnBack.TouchUpInside += (sender, e) =>
			{
				this.DismissViewController(true, null);
			};
		}

		/// <summary>
		/// Converts miles to latitude degrees
		/// </summary>
		public double MilesToLatitudeDegrees(double miles)
		{
			double earthRadius = 3960.0;
			double radiansToDegrees = 180.0 / Math.PI;
			return (miles / earthRadius) * radiansToDegrees;
		}

		/// <summary>
		/// Converts miles to longitudinal degrees at a specified latitude
		/// </summary>
		public double MilesToLongitudeDegrees(double miles, double atLatitude)
		{
			double earthRadius = 3960.0;
			double degreesToRadians = Math.PI / 180.0;
			double radiansToDegrees = 180.0 / Math.PI;

			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;
		}


		public class BasicMapAnnotation : MKAnnotation
		{
			/// <summary>
			/// The location of the annotation
			/// </summary>
			CLLocationCoordinate2D coord;

			public override CLLocationCoordinate2D Coordinate
			{
				get
				{
					return coord;
				}
			}

			protected string title;
			protected string subtitle;

			/// <summary>
			/// The title text
			/// </summary>
			public override string Title
			{ get { return title; } }


			/// <summary>
			/// The subtitle text
			/// </summary>
			public override string Subtitle
			{ get { return subtitle; } }

			public BasicMapAnnotation(CLLocationCoordinate2D coord, string title, string subTitle)
				: base()
			{
				this.coord = coord;
				this.title = title;
				this.subtitle = subTitle;
			}
		}


	}

	public class MapDelegate2 : MKMapViewDelegate
	{
		protected string annotationIdentifier = "BasicAnnotation";
		UIButton detailButton;
		MapKitViewController2 parent;

		public static int color = 1;
		public MapDelegate2(MapKitViewController2 parent)
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
				var detailAlert = UIAlertController.Create("Sathish Natarajan", "415 516 1334", UIAlertControllerStyle.Alert);

				detailAlert.AddAction(UIAlertAction.Create("RESCUE", UIAlertActionStyle.Default, (action) =>
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

		public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
		{

			if (mapView.UserLocation != null)
			{
				CLLocationCoordinate2D coords = mapView.UserLocation.Coordinate;
				MKCoordinateSpan span = new MKCoordinateSpan(MilesToLatitudeDegrees(1), MilesToLongitudeDegrees(1, coords.Latitude));
				mapView.Region = new MKCoordinateRegion(coords, span);


				mapView.AddAnnotation(new MKPointAnnotation()
				{
					Title = "Victim 5",
					Subtitle = "1 510 555-5555 - Rescue in progress",
					Coordinate = new CLLocationCoordinate2D(37.777257, -122.391061)
				});

			}


		}


		/// <summary>
		/// Converts miles to latitude degrees
		/// </summary>
		public double MilesToLatitudeDegrees(double miles)
		{
			double earthRadius = 3960.0;
			double radiansToDegrees = 180.0 / Math.PI;
			return (miles / earthRadius) * radiansToDegrees;
		}

		/// <summary>
		/// Converts miles to longitudinal degrees at a specified latitude
		/// </summary>
		public double MilesToLongitudeDegrees(double miles, double atLatitude)
		{
			double earthRadius = 3960.0;
			double degreesToRadians = Math.PI / 180.0;
			double radiansToDegrees = 180.0 / Math.PI;

			// derive the earth's radius at that point in latitude
			double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
			return (miles / radiusAtLatitude) * radiansToDegrees;
		}
    }
}