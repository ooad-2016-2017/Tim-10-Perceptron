using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace InteraktivnaMapaEvenata
{
    public sealed partial class OwnerEditEvent : Page
    {
        public EventVM EventVM { get { return DataContext as EventVM; } }

        public OwnerEditEvent(OwnerEventListVM OwnerEventListVM)
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            DataContext = ServiceModule.GetService<EventVM>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = e.Parameter;
        }
    }
}
