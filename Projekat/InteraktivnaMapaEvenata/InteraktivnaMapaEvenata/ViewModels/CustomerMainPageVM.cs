using InteraktivnaMapaEvenata.Customer.ViewModels;
using InteraktivnaMapaEvenata.Managers;
using InteraktivnaMapaEvenata.UserControls;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Customer.ViewModel
{
    public class CustomerMainPageVM : BaseVM
    {
        public List<UWP.Models.Customer> Customers { get; set; }

        public List<UWP.Models.Owner> Owners { get; set; }

        public List<Notification> Notifications { get; set; }

        public List<Event> Events { get; set; }

        private IEventService _eventService;

        public CustomerMainPageVM(IEventService eventService)
        {
            this._eventService = eventService;
        }

        public async Task<List<Event>> LoadEvents()
        {
            return await Task.Run(_eventService.GetEvents);
            //return this.Events = this._eventService.GetEvents();
        }
    }
}
