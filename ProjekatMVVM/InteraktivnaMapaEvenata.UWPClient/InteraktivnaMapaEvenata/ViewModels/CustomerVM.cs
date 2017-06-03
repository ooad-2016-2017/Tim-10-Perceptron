using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class CustomerVM : BaseVM
    {
        #region Data
        public List<Customer> Customers { get; set; }

        public List<Owner> Owners { get; set; }

        public List<Notification> Notifications { get; set; }

        public List<Event> Events { get; set; }
        #endregion

        #region Services
        private IEventService _eventService;
        private IOwnerService _ownerService;
        private ICustomerService _customerService;
        #endregion

        public CustomerVM(ICustomerService customerService,
            IOwnerService ownerService,
            IEventService eventService)
        {
            this._eventService = eventService;
            this._ownerService = ownerService;
            this._customerService = customerService;
        }

        public async Task<List<Event>> LoadEvents()
        {
            return await Task.Run(_eventService.GetEvents);
            //return this.Events = this._eventService.GetEvents();
        }
    }
}
