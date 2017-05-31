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
    public class LoginVM
    {
        public User User { get; set; }

        public RelayCommand LoginCommand { get; set; }


        public LoginVM()
        {

        }
    }
}
