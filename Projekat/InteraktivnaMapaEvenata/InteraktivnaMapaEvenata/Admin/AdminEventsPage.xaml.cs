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
    public sealed partial class AdminEventsPage : Page
    {
        List<Event> Events;

        public AdminEventsPage()
        {
            this.InitializeComponent();
            Events = new List<Event>();
            for (int i = 0; i < 10; i++)
                Events.Add(new Admin.Event()
                {
                    Name = "Event",
                    Subtitle = "Simply the best",
                    DateTime = new DateTime(1, 1, 1, 2, 2, 2),
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut sodales molestie ornare. Quisque porttitor in sem quis suscipit. Praesent non ullamcorper nunc, et facilisis risus. Curabitur interdum convallis dolor, vitae accumsan urna pulvinar ac. Fusce tincidunt sapien vitae diam eleifend sagittis. Nunc maximus augue aliquam arcu varius, ut gravida diam malesuada. Donec sed posuere odio."
                    + "Vestibulum pretium sit amet neque eget tempus.Duis lobortis sem at neque tempus,"
                    + "sit amet fringilla nibh pellentesque.Maecenas tempus risus nulla,"
                    + "ac lobortis leo ultrices auctor.Praesent a sem vel tortor molestie molestie nec ut ipsum.Quisque nec pulvinar augue,"
                    + "vel iaculis odio.Suspendisse at consectetur velit.Maecenas dictum,"
                    + "justo eu pellentesque auctor,"
                    + "enim mauris hendrerit quam,"
                    + "sed cursus lorem ligula et tellus.Curabitur et mi dui.In hac habitasse platea dictumst.Aenean eget turpis ut nisi mollis eleifend vel at nunc.Sed aliquam ullamcorper turpis,"
                    + "sit amet mollis tortor pulvinar ut.Class aptent taciti sociosqu ad litora torquent per conubia nostra,"
                    + "per inceptos himenaeos.Etiam aliquet urna ac tristique efficitur.Phasellus quis nisi ut magna euismod lobortis ut eget velit."
                });
            EventsList.ItemsSource = Events;
        }

        private void EventsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(AdminEventPage), (Event)e.ClickedItem);
        }
    }
}
