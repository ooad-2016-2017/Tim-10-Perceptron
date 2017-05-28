using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace InteraktivnaMapaEvenata.UserControls
{
    public sealed partial class ModalControl : UserControl
    {

        private Event _event;
        private Frame _frame;
        private string orgName;

        public ModalControl(Event _event, Frame frame)
        {
            this.InitializeComponent();
            this._event = _event;
            this._frame = frame;
            Initialize();
        }
        
        private void Initialize()
        {
            eventNameTextBlock.Text = "Naziv Eventa: " + _event.Name;
            eventTimeTextBlock.Text = "Vrijeme desavanja: " + _event.StartDate;
            eventOrganizerTextBlock.Text = "Organizator: ";
            orgName = _event.Owner.OrganizationName;
            eventInfoTextBlock.Text = "Info: " + _event.Description;
            eventDiscountTextBlock.Text = "Pogodnosti: " + _event.Promotion.Name;
        }

        private void eventOrganizerHyperlink_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(typeof(CustomerOwnerProfile), _event.Owner);
        }

        private void QRCodeHyperlink_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
