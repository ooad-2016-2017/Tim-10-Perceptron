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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InteraktivnaMapaEvenata.OwnerViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OwnerAccountType : Page
    {
        List<PaymentTier> PaymentTiers { get; set; }

        public OwnerAccountType()
        {
            // TODO: Fix!
            //this.InitializeComponent();

            PaymentTiers = new List<PaymentTier>();
            for (int i = 0; i < 3; i++)
            {
                PaymentTiers.Add(new PaymentTier()
                {
                    Price = 50.5,
                    Description = "description",
                    Label = "Label"
                });
            }

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OwnerPayment));
        }
    }
}
