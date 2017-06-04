using InteraktivnaMapaEvenata.Helpers;
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
    public class EventVM : BaseVM
    {
        #region ViewModels
        public AuthenticationVM AuthenticationVM { get; set; }
        #endregion

        #region Properties
        public string PromoDescription { get { return Event?.Promotion?.Description ?? ""; } }
        #endregion

        #region Model
        public Event Event { get; set; }
        private IEventService _eventService;
        private INavigationService _navigation;
        #endregion

        #region Commands
        public ICommand SignUp { get; set; }
        public ICommand SignOff { get; set; }
        public ICommand NavigateToOwner { get; set; }
        #endregion

        #region Initialization
        void InitCommands()
        {
            SignUp = new RelayCommand(async () =>
            {
                if (AuthenticationVM.IsCustomer())
                    await _eventService.SignUpUser(Event.EventId, AuthenticationVM.CurrentUser as Customer);
            });

            SignOff = new RelayCommand(async () =>
            {
                if (AuthenticationVM.IsCustomer())
                    await _eventService.SignOffUser(Event.EventId, AuthenticationVM.CurrentUser as Customer);
            });

            NavigateToOwner = new RelayCommand(() =>
            {
                _navigation.Navigate(typeof(CustomerOwnerProfile), Event.Owner);
            });
        }
        #endregion

        public EventVM(Event evnt, AuthenticationVM authenticationVM, IEventService eventService, INavigationService navigation)
        {
            _eventService = eventService;
            _navigation = navigation;
            AuthenticationVM = authenticationVM;
            Event = evnt;

            InitCommands();
        }
    }
}
