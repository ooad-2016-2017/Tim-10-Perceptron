using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InteraktivnaMapaEvenata
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public LoginVM LoginVM { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            LoginVM = new LoginVM(new AuthenticationVM(),
                ServiceModule.GetService<IAuthenticationService>(),
                ViewModelModule.GetService<INavigationService>(),
                ServiceModule.GetService<IUserService>(),
                ServiceModule.GetService<IOwnerService>(),
                ServiceModule.GetService<ICustomerService>());
        }
    }
}
