using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;
using InteraktivnaMapaEvenata.Helpers;
using System.Windows.Input;
using InteraktivnaMapaEvenata.Admin;
using Windows.UI.Xaml.Controls;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class AdminVM : BindableBase
    {
        public AuthenticationVM AuthenticationVM { get; set; }

        public ObservableRangeCollection<Event> Events { get; set; } = new ObservableRangeCollection<Event>();
        public ObservableRangeCollection<Owner> Owners { get; set; } = new ObservableRangeCollection<Owner>();
        public ObservableRangeCollection<Customer> Customers { get; set; } = new ObservableRangeCollection<Customer>();
        public ObservableRangeCollection<Flag> Flags { get; set; } = new ObservableRangeCollection<Flag>();

        public IEventService EventService { get; set; }
        public IOwnerService OwnerService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IEventVMFactory EventVMFactory { get; set; }
        public INavigationService Navigation { get; set; }

        public AdminVM(IEventService eventService,
            IEventVMFactory eventVMFactory,
            IOwnerService ownerService,
            ICustomerService customerService,
            INavigationService navigationService)
        {
            EventService = eventService;
            OwnerService = ownerService;
            CustomerService = customerService;
            EventVMFactory = eventVMFactory;
            Navigation = navigationService;
        }

        public async Task LoadData()
        {
            Events.AddRange(await EventService.GetEvents());
            Owners.AddRange(await OwnerService.GetOwners());
            Customers.AddRange(await CustomerService.GetCustomers());
        }

        public void NavigateToEventDetails(object evnt)
        {
            Navigation.Navigate(typeof(AdminEventPage), EventVMFactory.Create(evnt as Event,
                AuthenticationVM,
                EventService,
                Navigation));
        }
    }
}
