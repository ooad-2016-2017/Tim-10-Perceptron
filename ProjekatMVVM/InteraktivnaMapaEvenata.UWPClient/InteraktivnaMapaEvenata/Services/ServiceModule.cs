using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
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

            // Register services
            services.AddSingleton<IEventService, EventService>()
                .AddSingleton<IAuthenticationService, AuthenticationService>()
                .AddSingleton<IUserService, UserService>()
                .AddSingleton<ICustomerService, CustomerService>()
                .AddSingleton<IOwnerService, OwnerService>()
                .AddSingleton<INavigationService, NavigationService>();

            // Register factories
            services.AddSingleton<IEventVMFactory, EventVMFactory>()
                .AddSingleton<IOwnerDetailsVMFactory, OwnerDetailsVMFactory>();

            // Register viewmodels
            services.AddSingleton<AuthenticationVM>()
                .AddSingleton<AdminVM>()
                .AddSingleton<OwnerDetailsVM>()
                .AddSingleton<LoginVM>()
                .AddSingleton<CustomerVM>()
                .AddSingleton<OwnerEventListVM>()
                .AddTransient<EventVM>();

            Container = services.BuildServiceProvider();
        }

        public static T GetService<T>() 
        {
            return Container.GetService<T>();
        }

        public static IServiceProvider Container { get; set; }
    }
}

