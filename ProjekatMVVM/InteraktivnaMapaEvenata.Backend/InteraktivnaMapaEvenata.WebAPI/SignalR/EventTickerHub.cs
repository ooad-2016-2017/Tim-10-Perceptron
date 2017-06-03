using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace InteraktivnaMapaEvenata.WebAPI.SignalR
{
    public class EventTickerHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}