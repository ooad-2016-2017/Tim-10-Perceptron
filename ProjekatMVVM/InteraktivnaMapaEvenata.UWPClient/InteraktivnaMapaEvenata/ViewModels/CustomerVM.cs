using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        #endregion

        #region Services
        private IEventService _eventService;
        private IOwnerService _ownerService;
        private ICustomerService _customerService;
        private INavigationService _navigationService;
        #endregion

        #region Commands
        public ICommand ToggleHamburer { get; set; }
        public ICommand FindUsers { get; set; }
        public ICommand ToggleFavorites { get; set; }
        public ICommand NavigateToSettings{ get; set; }
        public ICommand NavigateToCustomerProfile { get; set; }
        public ICommand NavigateToOwnerProfile { get; set; }
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
        }

        #endregion

        public CustomerVM(ICustomerService customerService,
            IOwnerService ownerService,
            IEventService eventService,
            INavigationService navigationService,
            AuthenticationVM AuthenticationVM)
        {
            _eventService = eventService;
            _ownerService = ownerService;
            _customerService = customerService;
            _navigationService = navigationService;
            this.AuthenticationVM = AuthenticationVM;

            InitNavigation();
            InitCollections();
        }
        public async void Activate(object parameter)
        {
            Events.AddRange(await _eventService.GetEvents());
            Owners.AddRange(await _ownerService.GetOwners());
        }

        public void Deactivate(object parameter)
        {
        }
    }
}
