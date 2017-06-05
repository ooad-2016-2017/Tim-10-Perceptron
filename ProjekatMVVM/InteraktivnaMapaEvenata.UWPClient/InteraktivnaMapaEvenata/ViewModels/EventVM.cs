using InteraktivnaMapaEvenata.Admin;
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
    public class EventVM : BindableBase
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
        public ICommand NavigateToDetails { get; set; }
        public ICommand SignUpCallback { get; set; }
        public ICommand SignOffCallback { get; set; }
        #endregion

        private string signText;
        public string SignText { get { return signText; } set { SetProperty(ref signText, value); } }

        #region Initialization
        void InitCommands()
        {
            SignUp = new RelayCommand(async () =>
            {
                if (AuthenticationVM.IsCustomer() && SignText == "Prijavi se")
                {
                    SignText = "Odjavi se";
                    SignOffCallback?.Execute(Event);
                    AuthenticationVM.Customer.Events.Add(Event);
                    await _eventService.SignUpUser(Event.EventId, AuthenticationVM.CurrentUser as Customer);
                }
                else if (AuthenticationVM.IsCustomer())
                {
                    SignUpCallback?.Execute(Event);
                    SignText = "Prijavi se";
                    await _eventService.SignOffUser(Event.EventId, AuthenticationVM.CurrentUser as Customer);
                    AuthenticationVM.Customer.Events.ToList().RemoveAll(x => x.EventId == Event.EventId);
                }
            });

            SignOff = new RelayCommand(async () =>
            {
                if (AuthenticationVM.IsCustomer())
                {
                    await _eventService.SignOffUser(Event.EventId, AuthenticationVM.CurrentUser as Customer);
                    AuthenticationVM.Customer.Events.ToList().RemoveAll(x => x.EventId == Event.EventId);
                }
            });

            NavigateToOwner = new RelayCommand(() =>
            {
                _navigation.Navigate(typeof(CustomerOwnerProfile), Event.Owner);
            });

            NavigateToDetails = new RelayCommand(() =>
            {
                _navigation.Navigate(typeof(AdminEventPage), this);
            });
        }
        #endregion

        public void InitText()
        {
            if (Event?.Customers?.Where(x => x.CustomerId == AuthenticationVM.Customer.CustomerId)?.FirstOrDefault() == null)
            {
                SignText = "Prijavi se";
            }
            else
            {
                SignText = "Odjavi se";
            }
        }

        public EventVM(Event evnt, AuthenticationVM authenticationVM, IEventService eventService, INavigationService navigation)
        {
            _eventService = eventService;
            _navigation = navigation;
            AuthenticationVM = authenticationVM;
            Event = evnt;

            InitCommands();
            InitText();
        }
    }
}
