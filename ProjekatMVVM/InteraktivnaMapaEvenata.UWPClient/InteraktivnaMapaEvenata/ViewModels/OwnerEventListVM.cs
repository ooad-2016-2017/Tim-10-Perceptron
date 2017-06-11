using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class OwnerEventListVM : BaseVM
    {
        public AuthenticationVM AuthenticationVM { get; set; }
        public ObservableRangeCollection<Event> Events { get; set;  } = new ObservableRangeCollection<Event>();        

        public int EventCount { get { return Events.Count; } }

        public INavigationService NavigationService { get; set; }
        public IEventService EventService { get; set; }
        public ICommand FIllWithUserData { get; set; }
        public IEventVMFactory EventVMFactory { get; private set; }

        public OwnerEventListVM(IEventService eventService,
            INavigationService navigationService,
            AuthenticationVM authenticationVM,
            IEventVMFactory eventVMFactory)
        {
            EventVMFactory = eventVMFactory;
            AuthenticationVM = authenticationVM;
            EventService = eventService;
            NavigationService = navigationService;
            SetEvents();
            FIllWithUserData = new RelayCommand<object>(ComponentAdd, showUserData);
        }

        public void SetEvents()
        {
            Events.AddRange(AuthenticationVM.Owner.Events);
        }        

        public bool showUserData(object parameter)
        {
            return true;
        }

        public void ComponentAdd(object parameter)
        {
            NavigationService.GoBack();
        }

        public void EventClicked(object sender, ItemClickEventArgs e)
        {
            NavigationService.Navigate(typeof(OwnerEditEvent)/*, 
                EventVMFactory.Create(e.ClickedItem as Event, AuthenticationVM, EventService, NavigationService)*/);
        }

    }
}
