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
using InteraktivnaMapaEvenata.Services;

namespace InteraktivnaMapaEvenata.Admin
{
    public sealed partial class AdminMainPage : Page
    {
        public AdminVM AdminVM { get { return DataContext as AdminVM; } }

        public AdminMainPage()
        {
            this.InitializeComponent();
            DataContext = ServiceModule.GetService<AdminVM>();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.AdminVM.AuthenticationVM = e.Parameter as AuthenticationVM;
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
