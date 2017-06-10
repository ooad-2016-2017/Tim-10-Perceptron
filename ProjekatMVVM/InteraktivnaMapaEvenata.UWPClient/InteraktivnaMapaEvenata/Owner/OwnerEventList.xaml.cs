using InteraktivnaMapaEvenata.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using InteraktivnaMapaEvenata.Services;

namespace InteraktivnaMapaEvenata
{
    public sealed partial class OwnerEventList : Page
    {
    
        public OwnerEventListVM OwnerEventListVM { get { return DataContext as OwnerEventListVM; } }

        public OwnerEventList()
        {
            this.InitializeComponent();
            DataContext = ServiceModule.GetService<OwnerEventListVM>();
            NavigationCacheMode = NavigationCacheMode.Required;            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = ServiceModule.GetService<OwnerEventListVM>();
        }
    }
}
