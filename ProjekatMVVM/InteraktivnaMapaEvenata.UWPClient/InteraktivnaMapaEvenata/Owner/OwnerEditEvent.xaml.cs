using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace InteraktivnaMapaEvenata
{
    public sealed partial class OwnerEditEvent : Page
    {
        public int EventId { get; set; }

        public OwnerEditEvent(OwnerEventListVM OwnerEventListVM)
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            DataContext = ServiceModule.GetService<OwnerEventListVM>();
        }
    }
}
