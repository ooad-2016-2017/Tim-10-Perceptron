using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.System;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using InteraktivnaMapaEvenata.ViewModels;

namespace InteraktivnaMapaEvenata.Admin
{
    public sealed partial class AdminMainPage : Page
    {
        public AdminVM AdminVM { get; set; }

        public AdminMainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.AdminVM = e.Parameter as AdminVM;
            await AdminVM.LoadData();
        }

        private void EventsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AdminEventPage), e.ClickedItem);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void FlagsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AdminFlagInfoPage), e.ClickedItem);
        }
    }
}
