using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.Services.Interfaces;
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

namespace InteraktivnaMapaEvenata
{
    
    public sealed partial class OwnerEditEvent : Page
    {
        public int EventId { get; set; }

        public OwnerEditEvent()
        {
            this.InitializeComponent();
            DataContext = new OwnerEventListVM(ServiceModule.GetService<IEventService>());
            NavigationCacheMode = NavigationCacheMode.Required;
        }
        /*
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            EventId = (int)e.Parameter;
        }
        */
    }
}
