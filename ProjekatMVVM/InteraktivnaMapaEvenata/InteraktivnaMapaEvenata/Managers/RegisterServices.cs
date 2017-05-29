using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Managers
{
    public static class ServiceModule
    {
        public static void RegisterServices()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IEventService, EventMockService>();
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; set; }
    }
}
