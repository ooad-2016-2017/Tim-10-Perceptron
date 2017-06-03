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
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace InteraktivnaMapaEvenata.UserControls
{
    public sealed partial class MarkerControl : UserControl
    {
        private Event _event;
        private MapControl _mapControl;
        private Button _button;
        private Border _border;
        private TextBlock _textBlock;
        private Rectangle _rectangle;
        private ModalControl _modalControl;

        public Event Event { get { return _event; } }

        public MarkerControl(Event _event, MapControl mapControl, Frame frame)
        {
            this.InitializeComponent();
            this._event = _event;
            this._mapControl = mapControl;
            DisplayEventMarker();
            this._modalControl = new ModalControl(_event, frame);
            AddModal(_modalControl, _event.Latitude, _event.Longitude);
        }

        private void DisplayEventMarker()
        {
            // Specify a known location.
            //BasicGeoposition snPosition = new BasicGeoposition() { Latitude = eventt.latitude, Longitude = eventt.longitude };
            BasicGeoposition eventMarkerPosition = new BasicGeoposition() { Latitude = _event.Latitude, Longitude = _event.Longitude };
            BasicGeoposition eventMarkerLabelPosition = new BasicGeoposition() { Latitude = _event.Latitude + 0.000017, Longitude = _event.Longitude };
            Geopoint eventMarkerPoint = new Geopoint(eventMarkerPosition);
            Geopoint eventMarkerLabelPoint = new Geopoint(eventMarkerLabelPosition);

            // Create a XAML border.
            _border = new Border
            {
                Height = 20,
                Width = 20,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Blue),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(4)
            };

            _button = new Button
            {
                Height = 20,
                Width = 20,
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Transparent)
            };

            _textBlock = new TextBlock
            {
                Text = _event.Name
            };

            // Center the map over the POI.
            _mapControl.Center = eventMarkerPoint;
            _mapControl.ZoomLevel = 14;

            // Add XAML to the map.
            _mapControl.Children.Add(_button);
            _mapControl.Children.Add(_border);
            _mapControl.Children.Add(_textBlock);

            MapControl.SetLocation(_button, eventMarkerPoint);
            MapControl.SetLocation(_border, eventMarkerPoint);
            MapControl.SetLocation(_textBlock, eventMarkerLabelPoint);

            MapControl.SetNormalizedAnchorPoint(_button, new Point(0.5, 0.5));
            MapControl.SetNormalizedAnchorPoint(_border, new Point(0.5, 0.5));
            MapControl.SetNormalizedAnchorPoint(_textBlock, new Point(0.5, 0.5));

            _mapControl.ZoomLevelChanged += _mapControl_ZoomLevelChanged;
            _button.Click += _button_Click;
            _mapControl.CenterChanged += _mapControl_CenterChanged;
            _mapControl.MapTapped += _mapControl_MapTapped;

        }

        private void _mapControl_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            //  throw new NotImplementedException();
            _modalControl.Visibility = Visibility.Collapsed;
            _border.Visibility = Visibility.Visible;
            _button.Visibility = Visibility.Visible;
        }


        private void _mapControl_CenterChanged(MapControl sender, object args)
        {
            // throw new NotImplementedException();
            _modalControl.Visibility = Visibility.Collapsed;
            _border.Visibility = Visibility.Visible;
            _button.Visibility = Visibility.Visible;
        }

        private void _button_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            _button.Visibility = Visibility.Collapsed;
            _border.Visibility = Visibility.Collapsed;
            _modalControl.Visibility = Visibility.Visible;
        }

        private void _mapControl_ZoomLevelChanged(MapControl sender, object args)
        {
            //throw new NotImplementedException();

            if (_mapControl.ZoomLevel > 19)
            {
                _textBlock.Visibility = Visibility.Visible;
            }
            else _textBlock.Visibility = Visibility.Collapsed;
        }

        private void AddModal(ModalControl modalControl, double latitude, double longitude)
        {
            BasicGeoposition modalPosition = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };
            Geopoint modalPoint = new Geopoint(modalPosition);

            _mapControl.Children.Add(modalControl);
            MapControl.SetLocation(modalControl, modalPoint);
            MapControl.SetNormalizedAnchorPoint(modalControl, new Point(0.5, 0.5));

        }
    }
}