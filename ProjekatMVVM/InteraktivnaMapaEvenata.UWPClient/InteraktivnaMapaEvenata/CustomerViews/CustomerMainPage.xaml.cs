using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.UserControls;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;
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

namespace InteraktivnaMapaEvenata.CustomerViews
{
    public sealed partial class CustomerMainPage : Page
    {
        public CustomerVM CustomerVM { get; set; }

        public List<MarkerControl> MarkerControl { get; set; }


        public CustomerMainPage()
        {
            this.InitializeComponent();
            GetLocation();
            CustomerVM = ServiceModule.GetService<CustomerVM>();

            CustomerVM.Customers = new List<Customer>();
            for (int i = 0; i < 10; i++)
            {
                CustomerVM.Customers.Add(new UWP.Models.Customer()
                {
                    Name = "Vedo"
                });
            }

            CustomerVM.Owners = new List<Owner>();
            
            CustomerVM.Owners.Add(new UWP.Models.Owner()
            {
               OrganizationName = "Klix",
               Surname = "prezime",
               OwnerId = 1                  
            });

            CustomerVM.Owners.Add(new Owner()
            {
                OrganizationName = "SarajevoX",
                Surname = "prezime",
                OwnerId = 2
            });

            CustomerVM.Owners.Add(new Owner()
            {
                OrganizationName = "Portal",
                Surname = "prezime",
                OwnerId = 3
            });


            CustomerVM.Notifications = new List<Notification>();
            for (int i = 0; i < 10; i++)
            {
                CustomerVM.Notifications.Add(new Notification()
                {
                    Text = "textnotif"
                });
            }

            CustomerVM.Events = new List<Event>();
            Promotion promotion = new Promotion();
            promotion.Name = "Ime promocije";            
            CustomerVM.Events.Add(new Event()
            {
                Name = "PARTYYYYYYYYYY KOD VEDE",
                Description = "ovo je opis",
                StartDate = new DateTime(2017, 3, 17),
                Owner = CustomerVM.Owners[0],
                Promotion = promotion
            });
            CustomerVM.Events.Add(new Event()
            {
                Name = "GLASNA MUZIKA KOD ELVIRA",
                Description = "neki dobar opis",
                StartDate = new DateTime(2017, 4, 21),
                Owner = CustomerVM.Owners[0],
                Promotion = promotion
            });
            CustomerVM.Events.Add(new Event()
            {
                Name = "TIPKANJE KOD BURICA",
                Description = "jos bolji opis",
                StartDate = new DateTime(2017, 12, 12),
                Owner = CustomerVM.Owners[0],
                Promotion = promotion
            });


            CustomerVM.Owners[0].Events = CustomerVM.Events;           

            MarkerControl = new List<MarkerControl>();
            for (int i = 0; i < CustomerVM.Events.Count; i++)
            {
                MarkerControl.Add(new MarkerControl(CustomerVM.Events[i], MapControl1, frame));                
            }

        }      

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
       
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
            if (MySplitView.Visibility == Visibility.Collapsed)
            {
                hamburgerButton.Margin = new Thickness(0, 0, 0, 0);
                image.Margin = new Thickness(0, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/FrontArrow.png"));                
                MySplitView.Visibility = Visibility.Collapsed;                
            }
            else
            {
                hamburgerButton.Margin = new Thickness(200, 0, 0, 0);
                image.Margin = new Thickness(200, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/BackArrow.png"));
                MySplitView.Visibility = Visibility.Visible;
            }

        }

        private void findUsersButton_Click(object sender, RoutedEventArgs e)
        {
            if (findUsersRectangle.Visibility == Visibility.Collapsed)
            {
                findUsersRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);
            }
            else
            {
                findUsersRectangle.Visibility = Visibility.Collapsed;
                settingsButton.Margin = new Thickness(0, 0, 0, 0);
                favOrgButton.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        private void favOrgButton_Click(object sender, RoutedEventArgs e)
        {
            if (favOrgRectangle.Visibility == Visibility.Collapsed)
            {
                favOrgRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);              
            }
            else
            {
                favOrgRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            findUsersRectangle.Visibility = Visibility.Collapsed;
            favOrgRectangle.Visibility = Visibility.Collapsed;
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
