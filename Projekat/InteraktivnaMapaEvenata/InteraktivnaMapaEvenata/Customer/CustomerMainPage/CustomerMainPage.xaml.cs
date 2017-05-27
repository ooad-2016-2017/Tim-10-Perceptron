using InteraktivnaMapaEvenata.UserControls;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace InteraktivnaMapaEvenata.Customer
{
    public sealed partial class CustomerMainPage : Page
    {
        bool splitViewOpened = true;
        bool findUsersOpened = false;
        bool favoriteOpened = false;

        List<UWP.Models.Customer> Customers { get; set; }
        List<UWP.Models.Owner> Owners { get; set; }
        List<Notification> Notifications { get; set; }
        List<Event> Events { get; set; }

        List<MarkerControl> MarkerControl { get; set; }

        public CustomerMainPage()
        {
            this.InitializeComponent();
            //MapControl1.Loaded += MapControl1_Loaded;        
            //DisplayEventMarker(43.8699466, 18.4182643);
            GetLocation();
            //DisplayMarker();
            //MapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/customicon.png"));

            Customers = new List<UWP.Models.Customer>();
            for (int i = 0; i < 10; i++)
            {
                Customers.Add(new UWP.Models.Customer()
                {
                    Name = "Vedo"
                });
            }

            Owners = new List<UWP.Models.Owner>();
            
            Owners.Add(new UWP.Models.Owner()
            {
               OrganizationName = "Klix",
               Surname = "prezime",
               OwnerId = 1                  
            });

            Owners.Add(new UWP.Models.Owner()
            {
                OrganizationName = "SarajevoX",
                Surname = "prezime",
                OwnerId = 2
            });

            Owners.Add(new UWP.Models.Owner()
            {
                OrganizationName = "Portal",
                Surname = "prezime",
                OwnerId = 3
            });


            Notifications = new List<Notification>();
            for (int i = 0; i < 10; i++)
            {
                Notifications.Add(new Notification()
                {
                    Text = "textnotif"
                });
            }

            Events = new List<Event>();
            Promotion promotion = new Promotion();
            promotion.Name = "Ime promocije";
            for (int i = 0; i < 1; i++)
            {
                Events.Add(new Event()
                {
                    Name = "ACA LUKAS KOD VEDE",
                    Description = "ovo je opis",
                    StartDate = new DateTime(2017, 3, 17),
                    Owner = Owners[0],
                    Promotion = promotion
                });
            }

            MarkerControl = new List<MarkerControl>();
            for (int i = 0; i < Events.Count; i++)
            {
                MarkerControl.Add(new MarkerControl(Events[i], MapControl1));                
            }

        }        

        private void DisplayEventMarker(double latitude, double longitude/*, Button button*/)
        {
            // Specify a known location.
            BasicGeoposition snPosition = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };
            Geopoint snPoint = new Geopoint(snPosition);

            // Create a XAML border.
            Border border = new Border
            {
                Height = 20,
                Width = 20,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Blue),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(4)
            };

            Button button = new Button
            {
                Height = 20,
                Width = 20,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Transparent)
            };

            button.Click += new RoutedEventHandler(button_Click);

            // Center the map over the POI.
            MapControl1.Center = snPoint;
            MapControl1.ZoomLevel = 14;

            // Add XAML to the map.
            MapControl1.Children.Add(button);
            MapControl1.Children.Add(border);
            MapControl.SetLocation(button, snPoint);
            MapControl.SetLocation(border, snPoint);
            MapControl.SetNormalizedAnchorPoint(button, new Point(0.5, 0.5));
            MapControl.SetNormalizedAnchorPoint(border, new Point(0.5, 0.5));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        /*
        private void DisplayMarker()
        {
            // Specify a known location.
            BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 43.8699466, Longitude = 18.4182643 };
            Geopoint snPoint = new Geopoint(snPosition);

            // Create a MapIcon.
            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.Location = snPoint;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = "Vedo";
            mapIcon1.ZIndex = 0;

            // Add the MapIcon to the map.
            MapControl1.MapElements.Add(mapIcon1);

            // Center the map over the POI.
            /*MapControl1.Center = snPoint;
            MapControl1.ZoomLevel = 14;
        }
    */
        private async void GetLocation()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    // Get the current location.
                    Geolocator geolocator = new Geolocator();
                    Geoposition pos = await geolocator.GetGeopositionAsync();
                    Geopoint myLocation = pos.Coordinate.Point;

                    // Set the map location.
                    MapControl1.Center = myLocation;
                    MapControl1.ZoomLevel = 13;
                    MapControl1.LandmarksVisible = true;
                    break;

                case GeolocationAccessStatus.Denied:
                    // Handle the case  if access to location is denied.
                    break;

                case GeolocationAccessStatus.Unspecified:
                    // Handle the case if  an unspecified error occurs.
                    break;
            }
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!splitViewOpened)
            {
                splitViewOpened = true;
                hamburgerButton.Margin = new Thickness(0, 0, 0, 0);
                image.Margin = new Thickness(0, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/FrontArrow.png"));                
                MySplitView.Visibility = Visibility.Collapsed;                
            }
            else if (splitViewOpened)
            {
                splitViewOpened = false;
                hamburgerButton.Margin = new Thickness(200, 0, 0, 0);
                image.Margin = new Thickness(200, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/BackArrow.png"));
                MySplitView.Visibility = Visibility.Visible;
            }

        }

        private void findUsersButton_Click(object sender, RoutedEventArgs e)
        {
            if (!findUsersOpened)
            {
                findUsersOpened = true;
                findUsersRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);
            }
            else if(findUsersOpened)
            {
                findUsersOpened = false;
                findUsersRectangle.Visibility = Visibility.Collapsed;
                settingsButton.Margin = new Thickness(0, 0, 0, 0);
                favOrgButton.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        private void favOrgButton_Click(object sender, RoutedEventArgs e)
        {
            if (!favoriteOpened)
            {
                favoriteOpened = true;
                favOrgRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);              
            }
            else if (favoriteOpened)
            {
                favoriteOpened = true;
                favOrgRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            findUsersRectangle.Visibility = Visibility.Collapsed;
            favOrgRectangle.Visibility = Visibility.Collapsed;
            findUsersOpened = false;
            favoriteOpened = false;
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerEditProfile));
        }

        private void u1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerUserProfile));
        }

        private void o1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerOwnerProfile));
        }
    }
}
