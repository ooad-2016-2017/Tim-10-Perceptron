using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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

            services.AddSingleton<IEventService, EventService>()
                .AddSingleton<IAuthenticationService, AuthenticationService>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<ICustomerService, CustomerService>()
                .AddSingleton<IOwnerService, OwnerService>()
                .AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<AuthenticationVM>()
                .AddSingleton<AdminVM>()
                .AddSingleton<LoginVM>()
                .AddSingleton<CustomerVM>();

            Container = services.BuildServiceProvider();
        }

        public static T GetService<T>() 
        {
            if (Container == null)
                throw new Exception("RegisterServices must be called before using GetService");
            return Container.GetService<T>();
        }

        public static T GetService<T>(string Token) where T : BaseService
        {
            if (Container == null)
                throw new Exception("RegisterServices must be called before using GetService");
            return Container.GetService<T>().WithToken(Token);
        }

        public static IServiceProvider Container { get; set; }
    }
}

