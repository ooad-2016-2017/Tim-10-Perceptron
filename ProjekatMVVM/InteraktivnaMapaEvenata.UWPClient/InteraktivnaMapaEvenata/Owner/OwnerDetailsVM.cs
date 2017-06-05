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
    public class OwnerDetailsVM : BindableBase
    {
        string followLabel;
        public string FollowLabel { get { return followLabel; } set { SetProperty(ref followLabel, value); } }

        public AuthenticationVM AuthenticationVM { get; set; }

        public Owner Owner { get; set; }

        public ICommand Follow { get; set; }
        public ICommand ToggleFollow { get; set; }
        public ICommand Flag { get; set; }
        public ICommand BackToMain { get; set; }

        public INavigationService _navigation;
        public ICustomerService _customerService;

        public int Followers { get { return Owner.Followers?.Count ?? 0; } }

        public string FollowersText { get { return $"Pratilaca {Followers}"; } }

        void InitRelays()
        {
            ToggleFollow = new RelayCommand(() =>
            {
                if (FollowLabel == "Prati")
                {
                    FollowLabel = "Ne prati";
                    _customerService.Follow(AuthenticationVM.Customer.CustomerId, Owner.OwnerId);
                }
                else
                {
                    FollowLabel = "Prati";
                }
            });

            BackToMain = new RelayCommand(() => _navigation.Navigate(typeof(CustomerMainPageVM)));
        }

        public OwnerDetailsVM(Owner owner, AuthenticationVM authenticationVM, ICustomerService customerService, INavigationService navigation)
        {
            _navigation = navigation;
            _customerService = customerService;

            AuthenticationVM = authenticationVM;

            if (authenticationVM.Customer.FollowedOwners == null)
                authenticationVM.Customer.FollowedOwners = new List<Owner>();

            if (authenticationVM.Customer.FollowedOwners.Where(x => x.OwnerId == owner.OwnerId).FirstOrDefault() == null)
                FollowLabel = "Prati";
            else
                FollowLabel = "Ne prati";

            Owner = owner;

            if (Owner.Events == null)
                Owner.Events = new List<Event>();

            InitRelays();
        }
    }
}
