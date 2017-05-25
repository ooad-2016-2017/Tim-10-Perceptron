using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InteraktivnaMapaEvenata
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerMainPage : Page
    {
        bool splitViewOpened = true;
        bool findUsersOpened = false;
        bool favoriteOpened = false;

        public CustomerMainPage()
        {
            this.InitializeComponent();
            
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {

            if (!splitViewOpened)
            {
                splitViewOpened = true;
                hamburgerButton.Margin = new Thickness(0, 0, 0, 0);
                image.Margin = new Thickness(0, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/FrontArrow.png"));                
                MySplitView.Visibility = Visibility.Collapsed;                
            }
            else if (splitViewOpened)
            {
                splitViewOpened = false;
                hamburgerButton.Margin = new Thickness(200, 0, 0, 0);
                image.Margin = new Thickness(200, 0, 0, 0);
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/BackArrow.png"));
                MySplitView.Visibility = Visibility.Visible;
            }

        }

        private void findUsersButton_Click(object sender, RoutedEventArgs e)
        {
            if (!findUsersOpened)
            {
                findUsersOpened = true;
                findUsersRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);
            }
            else if(findUsersOpened)
            {
                findUsersOpened = false;
                findUsersRectangle.Visibility = Visibility.Collapsed;
                settingsButton.Margin = new Thickness(0, 0, 0, 0);
                favOrgButton.Margin = new Thickness(0, 0, 0, 0);
            }
        }

        private void favOrgButton_Click(object sender, RoutedEventArgs e)
        {
            if (!favoriteOpened)
            {
                favoriteOpened = true;
                favOrgRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);
            }
            else if (favoriteOpened)
            {
                favoriteOpened = true;
                favOrgRectangle.Visibility = Visibility.Visible;
                settingsButton.Margin = new Thickness(-250, 0, 0, 0);
                favOrgButton.Margin = new Thickness(-300, 0, 0, 0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            findUsersRectangle.Visibility = Visibility.Collapsed;
            favOrgRectangle.Visibility = Visibility.Collapsed;
            findUsersOpened = false;
            favoriteOpened = false;
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerEditProfile));
        }

        private void u1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerUserProfile));
        }

        private void o1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomerOwnerProfile));
        }
    }
}
