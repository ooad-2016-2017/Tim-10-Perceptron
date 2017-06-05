using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.UserControls;
using InteraktivnaMapaEvenata.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace InteraktivnaMapaEvenata.CustomerViews
{
    public sealed partial class CustomerMainPage : Page
    {
        public CustomerVM CustomerVM { get { return base.DataContext as CustomerVM; } set { base.DataContext = value; } }

        public List<MarkerControl> MarkerControl { get; set; } = new List<MarkerControl>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CustomerVM?.Activate(e.Parameter);
            MarkerControl.Clear();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            CustomerVM?.Deactivate(e.Parameter);
        }

        public CustomerMainPage()
        {
            this.InitializeComponent();
            GetLocation();
            DataContext = ServiceModule.GetService<CustomerVM>();
            CustomerVM.EventsVMs.CollectionChanged += EventChanged;
        }

        // https://stackoverflow.com/questions/1427471/observablecollection-not-noticing-when-item-in-it-changes-even-with-inotifyprop
        // TODO: Handle removes
        public void EventChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (EventVM item in e.NewItems)
                {
                    MarkerControl.Add(new MarkerControl(item, MainCustomerMap));
                }
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
                    MainCustomerMap.Center = myLocation;
                    MainCustomerMap.ZoomLevel = 13;
                    MainCustomerMap.LandmarksVisible = true;
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
                CustomerVM.RefreshCustomer.Execute(sender);
                hamburgerButton.Margin = new Thickness(200, 0, 0, 0);
                image.Margin = new Thickness(200, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/FrontArrow.png"));                
                MySplitView.Visibility = Visibility.Visible;
            }
            else
            {
                hamburgerButton.Margin = new Thickness(0, 0, 0, 0);
                image.Margin = new Thickness(0, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/BackArrow.png"));
                MySplitView.Visibility = Visibility.Collapsed;
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
    }
}
