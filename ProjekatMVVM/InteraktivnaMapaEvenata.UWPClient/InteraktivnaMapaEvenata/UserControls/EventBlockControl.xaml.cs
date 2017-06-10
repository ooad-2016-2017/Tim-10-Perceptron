using InteraktivnaMapaEvenata.Services;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace InteraktivnaMapaEvenata.UserControls
{
    public sealed partial class EventBlockControl : UserControl
    {
        public EventVM EventVM { get { return DataContext as EventVM; } }

        public EventBlockControl()
        {
            this.InitializeComponent();
        }


        public string eventName
        {
            get { return (string)GetValue(eventNameProperty); }
            set { SetValue(eventNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for eventName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty eventNameProperty =
            DependencyProperty.Register("eventName", typeof(string), typeof(EventBlockControl), null);


        public int eventFollowers
        {
            get { return (int)GetValue(eventFollowersProperty); }
            set { SetValue(eventFollowersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for eventNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty eventFollowersProperty =
            DependencyProperty.Register("eventFollowers", typeof(int), typeof(EventBlockControl), null);


        public UWP.Models.Owner Owner
        {
            get { return (UWP.Models.Owner)GetValue(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Owner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(UWP.Models.Owner), typeof(EventBlockControl), null);



        public int EventID
        {
            get { return (int)GetValue(EventIDProperty); }
            set { SetValue(EventIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for eventID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventIDProperty =
            DependencyProperty.Register("EventID", typeof(int), typeof(EventBlockControl), null);



        private void editEventButton_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(OwnerEditEvent), EventID);
        }
    }
}
