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

namespace InteraktivnaMapaEvenata.Admin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminOwnersPage : Page
    {
        List<UWP.Models.Owner> Owners;
        public AdminOwnersPage()
        {
            this.InitializeComponent();

            Owners = new List<UWP.Models.Owner>();

            for (int i = 0; i < 10; i++)
            {
                Owners.Add(new UWP.Models.Owner()
                {
                    Name = "John",
                    Surname = "Doe"
                });
            }

            //OwnersList.ItemsSource = Owners;
        }
    }
}
