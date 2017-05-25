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
    public sealed partial class AdminFlagInfoPage : Page
    {
        Flag Flag;
        public AdminFlagInfoPage()
        {
            this.InitializeComponent();
            Flag = new Flag();
        }

        public AdminFlagInfoPage(Flag Flag)
        {
            this.InitializeComponent();
            this.Flag = Flag;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Flag)
                this.Flag = (Flag)e.Parameter;
        }

        private async void DisplayTakeActionDialog()
        {
            ContentDialog takeAction = new ContentDialog
            {
                Title = "Odaberite radnju",
                PrimaryButtonText = "Izbrisi korisnika",
                SecondaryButtonText = "Izbrisi korisnika"
            };

            ContentDialogResult result = await takeAction.ShowAsync();
        }
        
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            DisplayTakeActionDialog();
        }
    }
}
