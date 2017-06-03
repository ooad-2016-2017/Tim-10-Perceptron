using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using InteraktivnaMapaEvenata.Services;

namespace InteraktivnaMapaEvenata
{
    public sealed partial class OwnerEventList : Page
    {
        public AuthenticationVM AuthenticationVM { get; set; }

        public OwnerEventList()
        {
            this.InitializeComponent();
            DataContext = ServiceModule.Container.GetService<OwnerEventListVM>();
            NavigationCacheMode = NavigationCacheMode.Required;            
        }
    }
}
