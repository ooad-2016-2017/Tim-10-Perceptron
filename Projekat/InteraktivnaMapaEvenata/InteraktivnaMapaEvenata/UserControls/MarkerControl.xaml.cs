using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace InteraktivnaMapaEvenata.UserControls
{
    public sealed partial class MarkerControl : UserControl
    {
        Event eventt;
        MapControl mapControl;
        Button button;
        Border border;

        public MarkerControl(Event eventt, MapControl mapControl)
        {
            this.InitializeComponent();
            this.eventt = eventt;
            this.mapControl = mapControl;
            DisplayEventMarker();        
              
        }       

        private void DisplayEventMarker()
        {
            // Specify a known location.
            //BasicGeoposition snPosition = new BasicGeoposition() { Latitude = eventt.latitude, Longitude = eventt.longitude };
            BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 43.8699466, Longitude = 18.4182643 };
            Geopoint snPoint = new Geopoint(snPosition);

            // Create a XAML border.
            border = new Border
            {
                Height = 20,
                Width = 20,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Blue),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(4)
            };

            button = new Button
            {
                Height = 20,
                Width = 20,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Transparent)
            };

            button.Click += new RoutedEventHandler(button_Click);

            // Center the map over the POI.
            mapControl.Center = snPoint;
            mapControl.ZoomLevel = 14;

            // Add XAML to the map.
            mapControl.Children.Add(button);
            mapControl.Children.Add(border);
            MapControl.SetLocation(button, snPoint);
            MapControl.SetLocation(border, snPoint);
            MapControl.SetNormalizedAnchorPoint(button, new Point(0.5, 0.5));
            MapControl.SetNormalizedAnchorPoint(border, new Point(0.5, 0.5));            

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.Visibility = Visibility.Collapsed;
        }
    }
}
