using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System.Collections.Generic;
using System.Linq;
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

        public string followersText;
        public string FollowersText { get { return followersText; } set { SetProperty(ref followersText, value); } }

        void InitRelays()
        {
            ToggleFollow = new RelayCommand(async () =>
            {
                if (FollowLabel == "Prati")
                {
                    FollowLabel = "Ne prati";
                    Owner.Followers.Add(AuthenticationVM.Customer);
                    FollowersText = $"Broj pratilaca: {Owner.Followers.Count}";
                    AuthenticationVM.Customer = await _customerService.Follow(AuthenticationVM.Customer.CustomerId, Owner.OwnerId);
                }
                else
                {
                    FollowLabel = "Prati";
                    Owner.Followers.Remove(Owner.Followers.Where(x => x.CustomerId == AuthenticationVM.Customer.CustomerId).FirstOrDefault());
                    FollowersText = $"Broj pratilaca: {Owner.Followers.Count}";
                    AuthenticationVM.Customer = await _customerService.Unfollow(AuthenticationVM.Customer.CustomerId, Owner.OwnerId);
                }
            });

            BackToMain = new RelayCommand(() => _navigation.Navigate(typeof(CustomerMainPageVM)));
        }

        public OwnerDetailsVM(Owner owner, AuthenticationVM authenticationVM, ICustomerService customerService, INavigationService navigation)
        {
            _navigation = navigation;
            _customerService = customerService;

            FollowersText = $"Broj pratilaca: {owner.Followers.Count}";

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
