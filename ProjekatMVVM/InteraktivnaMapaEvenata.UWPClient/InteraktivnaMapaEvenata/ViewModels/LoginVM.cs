using InteraktivnaMapaEvenata.Admin;
using InteraktivnaMapaEvenata.CustomerViews;
using InteraktivnaMapaEvenata.DTO;
using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class LoginVM : BindableBase
    {
        #region services
        private IAuthenticationService _authService;
        private INavigationService _navigation;
        private IUserService _userService;
        private IOwnerService _ownerService;
        private ICustomerService _customerService;
        #endregion

        #region Binding
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set { this.SetProperty(ref this.username, value); }
        }

        public string Password
        {
            get { return password; }
            set { this.SetProperty(ref this.password, value); }
        }
        #endregion

        #region ViewModels
        public AuthenticationVM AuthenticationVM { get; set; }
        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }
        #endregion


        public LoginVM(AuthenticationVM authenticationVM,
                        IAuthenticationService authService,
                        INavigationService navigation,
                        IUserService userService,
                        IOwnerService ownerService,
                        ICustomerService customerService)
        {
            this.AuthenticationVM = authenticationVM;
            this._authService = authService;
            this._userService = userService;
            this._ownerService = ownerService;
            this._customerService = customerService;
            this._navigation = navigation;

            LoginCommand = new RelayCommand(DoLogin);
        }

        // TODO: Handle network errors

        private async void DoLogin()
        {
            AuthDTO authDTO = await _authService.LogIn(Username, Password);
            AuthenticationVM.Token = authDTO.access_token;

            _userService.Token = authDTO.access_token;
            _customerService.Token = authDTO.access_token;
            _ownerService.Token = authDTO.access_token;

            if (authDTO.role == AuthenticationVM.ADMIN_ROLE)
            {
                AuthenticationVM.CurrentUser = await _userService.GetUser(authDTO.userId);
                _navigation.Navigate(typeof(AdminMainPage), ServiceModule.GetService<AdminVM>());
            }
            else if (authDTO.role == AuthenticationVM.CUSTOMER_ROLE)
            {
                AuthenticationVM.CurrentUser = await _customerService.GetCustomer(authDTO.userId);
                _navigation.Navigate(typeof(CustomerMainPage), AuthenticationVM);
            }
            else if (authDTO.role == AuthenticationVM.OWNER_ROLE)
            {
                AuthenticationVM.CurrentUser = await _ownerService.GetOwner(authDTO.userId);
                _navigation.Navigate(typeof(OwnerMainPage), AuthenticationVM);
            }

        }
    }
}
