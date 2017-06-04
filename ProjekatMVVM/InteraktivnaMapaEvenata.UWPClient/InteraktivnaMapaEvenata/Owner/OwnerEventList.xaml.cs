using InteraktivnaMapaEvenata.ViewModels;
using Windows.UI.Xaml.Controls;
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
