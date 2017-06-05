using InteraktivnaMapaEvenata.CustomerViews;
using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.UserControls;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;
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

namespace InteraktivnaMapaEvenata
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerOwnerProfile : Page
    {
        public OwnerDetailsVM OwnerDetailsVM { get { return DataContext as OwnerDetailsVM; } }

        public EventBlockControl EventBlockControl { get; set; }

        public CustomerOwnerProfile()
        {
            this.InitializeComponent();
            this.DataContext = ServiceModule.GetService<OwnerDetailsVM>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!Frame.CanGoBack)
            {
                backButton.Visibility = Visibility.Visible;
            }
            DataContext = e.Parameter;
        }
    }
}
