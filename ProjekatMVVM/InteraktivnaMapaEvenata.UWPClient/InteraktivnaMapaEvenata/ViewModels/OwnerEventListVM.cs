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
    class OwnerEventListVM : BaseVM
    {
        public List<Event> Events { get; set; }

        public int EventCount { get; set; }

        public NavigationService NavigationService { get; set; }

        public IEventService EventService { get; set; }

        public ICommand FIllWithUserData { get; set; }        

        public OwnerEventListVM(IEventService EventService)
        {
            this.EventService = EventService;
            SetEvents();
            EventCount = Events.Count;
            NavigationService = new NavigationService();
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
