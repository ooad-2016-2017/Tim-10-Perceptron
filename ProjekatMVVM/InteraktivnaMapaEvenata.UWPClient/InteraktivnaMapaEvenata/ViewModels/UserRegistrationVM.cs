using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Registration;
using InteraktivnaMapaEvenata.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteraktivnaMapaEvenata.ViewModels {
    public class UserRegistrationVM : BindableBase {

        INavigationService _navigation;

        public ICommand NavigateCustomer { get; set; }
        public ICommand NavigateOwner { get; set; }

        public UserRegistrationVM(INavigationService navigation)
        {

            this._navigation = navigation;
            NavigateCustomer = new RelayCommand(NavigateCustomerAction);
            NavigateOwner = new RelayCommand(NavigateOwnerAction);

        }

        private void NavigateCustomerAction()
        {
            _navigation.Navigate(typeof(CustomerRegistrationLoginData), ServiceModule.GetService<CustomerRegistrationVM>());
        }

        private void NavigateOwnerAction()
        {
            _navigation.Navigate(typeof(OwnerRegistrationLoginData), ServiceModule.GetService<OwnerRegistrationVM>());
        }
    }
}
