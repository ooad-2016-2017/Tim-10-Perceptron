using InteraktivnaMapaEvenata.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public static class ViewModelModule
    {
        public static void RegisterHelpers()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
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
