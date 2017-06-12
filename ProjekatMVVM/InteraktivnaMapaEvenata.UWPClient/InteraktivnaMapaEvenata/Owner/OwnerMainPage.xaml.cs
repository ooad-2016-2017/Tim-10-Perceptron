using InteraktivnaMapaEvenata.OwnerViews;
using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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

namespace InteraktivnaMapaEvenata
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OwnerMainPage : Page
    {
        OwnerVM OwnerVM { get { return DataContext as OwnerVM; } }
        public OwnerMainPage()
        {
            this.InitializeComponent();
            DataContext = ServiceModule.GetService<CustomerVM>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = ServiceModule.GetService<CustomerVM>();
            OwnerVM?.Activate(e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            OwnerVM?.Deactivate(e.Parameter);
        }

        private void viewEventsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OwnerEventList));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OwnerEditProfile));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OwnerAccountType));
        }        
        
    }
}
