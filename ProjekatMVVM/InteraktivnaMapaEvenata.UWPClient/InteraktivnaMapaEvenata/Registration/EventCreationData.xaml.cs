using InteraktivnaMapaEvenata.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InteraktivnaMapaEvenata.Registration {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventCreationData : Page {

        public EventRegistrationVM EventRegistrationVM { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.EventRegistrationVM = e.Parameter as EventRegistrationVM;
        }

        public EventCreationData()
        {
            this.InitializeComponent();
        }
    }
}
