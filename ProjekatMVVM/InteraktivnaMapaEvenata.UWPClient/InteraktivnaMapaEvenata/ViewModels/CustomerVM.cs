using InteraktivnaMapaEvenata.Helpers;

using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class CustomerVM : BaseVM, INavigable
    {
        #region ViewModels
        public AuthenticationVM AuthenticationVM { get; private set; }
        #endregion

        #region Data
        public ObservableRangeCollection<Customer> Customers { get; set; }
        public ObservableRangeCollection<Owner> Owners { get; set; }
        public ObservableRangeCollection<Notification> Notifications { get; set; }
        public ObservableRangeCollection<Event> Events { get; set; }
        public ObservableRangeCollection<EventVM> EventsVMs { get; set; }

        #endregion

        #region Services
        private IEventService _eventService;
        private IOwnerService _ownerService;
        private IOwnerDetailsVMFactory _ownerDetailsFactory;
        private ICustomerService _customerService;
        private INavigationService _navigationService;
        private IEventVMFactory _eventVMFactory;
        #endregion

        #region Commands
        public ICommand ToggleHamburer { get; set; }
        public ICommand FindUsers { get; set; }
        public ICommand ToggleFavorites { get; set; }
        public ICommand NavigateToSettings{ get; set; }
        public ICommand NavigateToCustomerProfile { get; set; }
        public ICommand NavigateToOwnerProfile { get; set; }
        public ICommand RefreshCustomer { get; set; }
        #endregion

        #region Initialization
        void InitNavigation()
        {
            NavigateToSettings = new RelayCommand(() => { _navigationService.Navigate(typeof(CustomerEditProfile)); });
            NavigateToCustomerProfile = new RelayCommand(() => { _navigationService.Navigate(typeof(CustomerUserProfile)); });
            NavigateToOwnerProfile = new RelayCommand(() => { _navigationService.Navigate(typeof(CustomerOwnerProfile)); });
        }

        void InitCollections()
        {
            Customers = new ObservableRangeCollection<Customer>();
            Owners = new ObservableRangeCollection<Owner>();
            Notifications = new ObservableRangeCollection<Notification>();
            Events = new ObservableRangeCollection<Event>();
            EventsVMs = new ObservableRangeCollection<EventVM>();
        }

        void InitRelays()
        {
            RefreshCustomer = new RelayCommand(async () =>
            {
                var customer = await _customerService.GetCustomer(AuthenticationVM.Customer.CustomerId);

            });
        }

        public EventVM CreateEventVM(Event item)
        {
            return _eventVMFactory.Create(item, AuthenticationVM, _eventService, _navigationService);
        }
        #endregion

        // TODO: Consider making this into a facade.
        public CustomerVM(ICustomerService customerService,
            IOwnerService ownerService,
            IOwnerDetailsVMFactory ownerFactory,
            IEventService eventService,
            INavigationService navigationService,
            IEventVMFactory eventVMFactory,
            AuthenticationVM AuthenticationVM)
        {
            _ownerDetailsFactory = ownerFactory;
            _eventService = eventService;
            _ownerService = ownerService;
            _customerService = customerService;
            _navigationService = navigationService;
            _eventVMFactory = eventVMFactory;
            this.AuthenticationVM = AuthenticationVM;

            InitNavigation();
            InitCollections();
            InitRelays();

            Events.CollectionChanged += handleEventAdd;
        }

        // TODO: Handle removes
        private void handleEventAdd(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Event item in e.NewItems)
                {
                    EventsVMs.Add(CreateEventVM(item));
                }
            }
        }

        public async void Activate(object parameter)
        {
            Owners.Clear();
            Events.Clear();
            Events.AddRange(await _eventService.GetEvents());
            Owners.AddRange(await _ownerService.GetOwners());
        }

        public void Deactivate(object parameter)
        {
        }

        public void OwnerClicked(object sender, ItemClickEventArgs e)
        {
            _navigationService.Navigate(typeof(CustomerOwnerProfile), 
                _ownerDetailsFactory.Create((Owner)e.ClickedItem, AuthenticationVM, _customerService, _navigationService));
        }

    }
}
