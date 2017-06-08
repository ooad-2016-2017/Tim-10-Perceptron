using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Registration;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using static InteraktivnaMapaEvenata.UWP.Models.Customer;

namespace InteraktivnaMapaEvenata.ViewModels {
    public class CustomerRegistrationVM : BindableBase {
        #region services
        INavigationService _navigation;
        ICustomerService _customer;
        IUserService _user;
        #endregion

        #region Binding
        private string username;
        private string password;
        private string email;
        private string firstName;
        private string lastName;
        private Customer.Genders gender;
        private byte[] profileImage;
        private DateTimeOffset dateOfBirth = DateTime.Now;

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

        public string Email
        {
            get { return email; }
            set { this.SetProperty(ref this.email, value); }
        }

        public string FirstName
        {
            get { return firstName; }
            set { this.SetProperty(ref this.firstName, value); }
        }

        public string LastName
        {
            get { return lastName; }
            set { this.SetProperty(ref this.lastName, value); }
        }

        public Genders Gender
        {
            get { return gender; }
            set { this.SetProperty(ref this.gender, value); }
        }

        public DateTimeOffset DateOfBirth
        {
            get { return dateOfBirth; }
            set { this.SetProperty(ref this.dateOfBirth, value); }
        }

        public byte[] ProfileImage
        {
            get { return profileImage; }
            set { this.SetProperty(ref this.profileImage, value); }
        }

        public bool? GenderAsMale
        {
            get { return Gender.Equals(Genders.Male); }
            set { Gender = Genders.Male; }
        }

        public bool? GenderAsFemale
        {
            get { return Gender.Equals(Genders.Female); }
            set { Gender = Genders.Female; }
        }
        #endregion

        #region ViewModels
        #endregion

        #region Commands
        public ICommand NextLoginData { get; set; }
        public ICommand NextPersonalData { get; set; }
        public ICommand NextInterests { get; set; }
        public ICommand PreviousInterests { get; set; }
        public ICommand PreviousPersonalData { get; set; }
        public ICommand BackToLogin { get; set; }
        #endregion


        public CustomerRegistrationVM(IUserService user, ICustomerService customer, INavigationService navigation)
        {
            this._navigation = navigation;
            this._customer = customer;
            this._user = user;
            NextLoginData = new RelayCommand(NextLoginDataAction);
            NextPersonalData = new RelayCommand(NextPersonalDataAction);
            NextInterests = new RelayCommand(NextInterestsAction);
            PreviousInterests = new RelayCommand(PreviousInterestsAction);
            PreviousPersonalData = new RelayCommand(PreviousPersonalDataAction);
            BackToLogin = new RelayCommand(BackToLoginAction);
            //ChooseTier = new RelayCommand(ChooseTierAction);
        }

        // TODO: Handle network errors

        private void BackToLoginAction()
        {
            _navigation.Navigate(typeof(MainPage));
        }

        private void ValidateEmpty(string field)
        {
            if (field == null || field == "")
                throw new Exception("Prazno polje");
        }

        private void ValidateDate()
        {
            if (dateOfBirth > DateTime.Now)
                throw new Exception("Pogresan datum");
            if (dateOfBirth > DateTime.Now.AddYears(-18))
                throw new Exception("Premladi ste za aplikaciju");
        }

        private void ValidateEmail()
        {
            string email = Email;
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);
            Match match = regex.Match(email);
            if (!match.Success)
                throw new Exception("Neispravan mail");
        }

        private async void NextLoginDataAction()
        {
            try
            {
                ValidateEmpty(Username);
                ValidateEmpty(Password);
                ValidateEmpty(Email);
                ValidateEmail();
                _navigation.Navigate(typeof(CustomerRegistrationPersonalData), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private async void NextPersonalDataAction()
        {
            try
            {
                ValidateEmpty(FirstName);
                ValidateEmpty(LastName);
                ValidateDate();
                _navigation.Navigate(typeof(CustomerRegistrationInterests), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private void PreviousPersonalDataAction()
        {
            _navigation.Navigate(typeof(CustomerRegistrationLoginData), this);
        }


        private async void NextInterestsAction()
        {
            try
            {
                _navigation.Navigate(typeof(CustomerRegistrationSuccess), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private void PreviousInterestsAction()
        {
            _navigation.Navigate(typeof(CustomerRegistrationPersonalData), this);
        }
    }
}
