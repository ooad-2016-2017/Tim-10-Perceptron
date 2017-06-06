using Flurl.Http;
using InteraktivnaMapaEvenata.Admin;
using InteraktivnaMapaEvenata.CustomerViews;
using InteraktivnaMapaEvenata.DTO;
using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Registration;
using InteraktivnaMapaEvenata.Services;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

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
        public ICommand RegisterCommand { get; set; }
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
            RegisterCommand = new RelayCommand(DoRegister);
        }

        // TODO: Handle network errors

        private void DoRegister()
        {
            _navigation.Navigate(typeof(RegistrationPicker), ServiceModule.GetService<UserRegistrationVM>());
        }

        private async void DoLogin()
        {
            try
            {
                AuthDTO authDTO = await _authService.LogIn(Username, Password);
                BaseService.Token = authDTO.access_token;

                if (authDTO.role == AuthenticationVM.ADMIN_ROLE)
                {
                    AuthenticationVM.CurrentUser = await _userService.GetUser(authDTO.userId);
                    _navigation.Navigate(typeof(AdminMainPage), AuthenticationVM);
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
            catch (FlurlHttpException e)
            {
                var messageDialog = new MessageDialog("Username ili password su pogresni!");
                await messageDialog.ShowAsync();
            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog("Problem sa mrezom!");
                await messageDialog.ShowAsync();
            }
        }
    }
}
