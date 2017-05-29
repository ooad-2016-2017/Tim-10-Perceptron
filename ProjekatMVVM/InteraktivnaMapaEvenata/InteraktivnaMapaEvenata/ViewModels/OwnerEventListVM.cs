using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Managers;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteraktivnaMapaEvenata.ViewModels
{
    class OwnerEventListVM
    {
        
        public List<Event> Events { get; set; }
        public int EventCount { get; set; }

        public NavigationService NavigationService { get; set; }
        public EventMockService EventMockService { get; set; }

        public ICommand FIllWithUserData { get; set; }        

        public OwnerEventListVM()
        {
            EventMockService = new EventMockService();
            SetEvents();
            EventCount = Events.Count;
            NavigationService = new NavigationService();
            FIllWithUserData = new RelayCommand<object>(dodavanjeKomponente, showUserData);
        }

        public async void SetEvents()
        {
            Events = await EventMockService.GetEvents();
        }        

        public bool showUserData(object parameter)
        {
            return true;
        }

        public void dodavanjeKomponente(object parameter)
        {
            NavigationService.GoBack();
        }

    }
}
