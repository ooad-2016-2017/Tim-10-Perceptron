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
    public sealed partial class AdminFlagsPage : Page
    {
        List<Flag> Flags;

        public AdminFlagsPage()
        {
            this.InitializeComponent();

            Flags = new List<Flag>();

            for (int i = 0; i < 10; i++)
            {
                Flags.Add(new Flag()
                {
                    Username = "elvircrn",
                    Category = "Jer sam budala",
                    Explanation = "Morbi orci libero, aliquet a ligula ac, rhoncus condimentum purus. Quisque et dui lacus. In eleifend a quam et rutrum. Aenean quam nunc, sodales eget blandit nec, auctor eu augue. Fusce eget convallis velit, id convallis elit. Ut in varius tellus. Nam commodo erat fringilla ex aliquam ornare. Vivamus ullamcorper semper mattis. Praesent porttitor imperdiet sollicitudin. In dictum leo id velit tempus, nec accumsan augue ultricies. Cras lacus elit, tempor porttitor ligula vel, feugiat gravida lectus. Aenean condimentum ipsum sit amet nisl finibus, id elementum purus tincidunt."
                });
            }
        }

        private void FlagsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AdminFlagInfoPage), (Flag)e.ClickedItem);
        }
    }
}
