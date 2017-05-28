using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Managers
{
    public sealed class EventManager
    {
        public IEventService Service { get; set; }

        public EventManager(IEventService service)
        {
            this.Service = service;
        }
    }
}

