using InteraktivnaMapaEvenata.Customer;
using InteraktivnaMapaEvenata.UserControls;
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

        //private UWP.Models.Owner owner;
        public List<UWP.Models.Event> Events { get; set; }
        public EventBlockControl EventBlockControl { get; set; }
        public UWP.Models.Owner Owner { get; set; }
        public int Followers { get; set; }
        public string FollowersText { get; set; }

        public CustomerOwnerProfile()
        {
            this.InitializeComponent();
            this.DataContext = this;
            Events = new List<UWP.Models.Event>();
            /*
             * ako customer prati followButton content = prekini pracenje ako ne prati followButton content = prati
             */
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // base.OnNavigatedTo(e);
            if (!Frame.CanGoBack)
            {
                backButton.Visibility = Visibility.Visible;
            }
            Owner = (UWP.Models.Owner)e.Parameter;
            Events = (List<UWP.Models.Event>)Owner.Events;
           // EventBlockControl = new EventBlockControl(Events[0]);
            if (Owner.Followers == null) Followers = 0;
            else Followers = Owner.Followers.Count;
            FollowersText = "Pratilaca: " + Followers.ToString();
        }
        
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerMainPage));
        }

        private void followButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)followButton.Content == "Prati")
            {
                followButton.Content = "Ne prati";
            }
            else followButton.Content = "Prati";
        }

        private void flagButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
