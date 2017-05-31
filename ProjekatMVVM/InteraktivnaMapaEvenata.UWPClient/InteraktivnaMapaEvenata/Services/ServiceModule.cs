using InteraktivnaMapaEvenata.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services
{
    public static class ServiceModule
    {
        public static void RegisterServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IEventService, EventMockService>()
                .AddSingleton<IAuthenticationService, AuthenticationService>();

            Container = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            if (Container == null)
                throw new Exception("RegisterServices must be called before using GetService");
            return Container.GetService<T>();
        }

        public static IServiceProvider Container { get; set; }
    }
}

