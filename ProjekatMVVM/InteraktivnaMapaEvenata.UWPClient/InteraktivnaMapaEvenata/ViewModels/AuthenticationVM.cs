using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class AuthenticationVM : BaseVM
    {
        private bool _IsAuthenticated;

        public static readonly string ADMIN_ROLE = "ADMIN";
        public static readonly string OWNER_ROLE = "OWNER";
        public static readonly string CUSTOMER_ROLE = "CUSTOMER";
        public static readonly string QR_ROLE = "QR";

        public string Token { get; set; }

        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set
            {
                if (value != _IsAuthenticated)
                {
                    _IsAuthenticated = value;
                    RaisePropertyChanged("IsAuthenticated");
                    RaisePropertyChanged("IsNotAuthenticated");
                }
            }
        }

        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        public bool CanDoAuthenticated(object ignore)
        {
            return IsAuthenticated;
        }

        private User _CurrentUser;
        public User CurrentUser
        {
            get { return _CurrentUser; }
            set

            {
                if (value != _CurrentUser)
                {
                    _CurrentUser = value;
                    RaisePropertyChanged("CurrentUser");
                }
            }
        }

        public void Authenticate()
        {
            IsAuthenticated = true;
        }

        public void LogOff()
        {
            IsAuthenticated = false;
        }
    }
}
