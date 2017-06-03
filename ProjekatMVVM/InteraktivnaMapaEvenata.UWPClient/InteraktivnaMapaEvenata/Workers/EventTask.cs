using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace InteraktivnaMapaEvenata.Workers
{
    public sealed class EventTask : IBackgroundTask
    {
        IEventService service;
        DateTime datePing;
        Func<Event> callback;

        public EventTask(IEventService service, DateTime datePing, Func<Event> callback)
        {
            this.callback = callback;
            this.datePing = datePing;
            this.service = service;
        }
        
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            for (;;)
            {
            }
        }
    }
}
