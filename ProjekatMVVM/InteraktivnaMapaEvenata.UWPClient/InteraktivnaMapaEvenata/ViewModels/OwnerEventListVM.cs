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

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class OwnerEventListVM : BaseVM
    {
        public List<Event> Events { get; set; }

        public int EventCount { get { return Events.Count; } }

        public INavigationService NavigationService { get; set; }

        public IEventService EventService { get; set; }

        public ICommand FIllWithUserData { get; set; }        

        public OwnerEventListVM(IEventService EventService,
            INavigationService NavigationService)
        {
            this.EventService = EventService;
            this.NavigationService = NavigationService;
            SetEvents();
            FIllWithUserData = new RelayCommand<object>(ComponentAdd, showUserData);
        }

        public async void SetEvents()
        {
            Events = await EventService.GetEvents();
        }        

        public bool showUserData(object parameter)
        {
            return true;
        }

        public void ComponentAdd(object parameter)
        {
            NavigationService.GoBack();
        }

    }
}
