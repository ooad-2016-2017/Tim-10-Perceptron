using InteraktivnaMapaEvenata.Helpers;
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
        public string FollowLabel { get; set; }

        public Owner Owner { get; set; }

        public ICommand Follow { get; set; }
        public ICommand ToggleFollow { get; set; }
        public ICommand Flag { get; set; }
        public ICommand BackToMain { get; set; }

        public INavigationService _navigation;

        public int Followers { get { return Owner.Followers?.Count ?? 0; } }

        public string FollowersText { get { return $"Pratilaca {Followers}"; } }

        void InitRelays()
        {
            ToggleFollow = new RelayCommand(() =>
            {
                if (FollowLabel == "Prati")
                    FollowLabel = "Ne prati";
                else
                    FollowLabel = "Prati";
            });

            BackToMain = new RelayCommand(() => _navigation.Navigate(typeof(CustomerMainPageVM)));
        }

        public OwnerDetailsVM(Owner owner, INavigationService navigation)
        {
            _navigation = navigation;
            Owner = owner;

            if (Owner.Events == null)
                Owner.Events = new List<Event>();

            InitRelays();
        }
    }
}
