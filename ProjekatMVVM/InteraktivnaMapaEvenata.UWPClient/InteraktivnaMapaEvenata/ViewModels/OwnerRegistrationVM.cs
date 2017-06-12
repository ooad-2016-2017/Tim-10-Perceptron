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

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class OwnerRegistrationVM : BindableBase
    {
        #region services
        INavigationService _navigation;
        IOwnerService _owner;
        IUserService _user;
        #endregion

        #region Binding
        private string username;
        private string password;
        private string email;
        private string info;
        private string organizationName;
        private string ownerName;
        private byte[] profileImage;

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
            set { this.SetProperty(ref this.email, value);  }
        }

        public string OwnerName
        {
            get { return ownerName; }
            set { this.SetProperty(ref this.ownerName, value); }
        }

        public string OrganizationName
        {
            get { return organizationName; }
            set { this.SetProperty(ref this.organizationName, value); }
        }

        public string Info
        {
            get { return info; }
            set { this.SetProperty(ref this.info, value); }
        }

        public byte[] ProfileImage
        {
            get { return profileImage; }
            set { this.SetProperty(ref this.profileImage, value); }
        }
        #endregion

        #region ViewModels
        #endregion

        #region Commands
        public ICommand NextLoginInfo { get; set; }
        public ICommand NextOrganizationInfo { get; set; }
        public ICommand NextPaymentInfo { get; set; }
        public ICommand NextPaymentTier { get; set; }
        public ICommand PreviousOrganizationInfo { get; set; }
        public ICommand PreviousPaymentInfo { get; set; }
        public ICommand PreviousPaymentTier { get; set; }
        public ICommand ChooseTier { get; set; }
        public ICommand BackToLogin { get; set; }
        #endregion


        public OwnerRegistrationVM(IUserService user, IOwnerService owner, INavigationService navigation)       
        {

            this._navigation = navigation;
            this._owner = owner;
            this._user = user;
            NextLoginInfo = new RelayCommand(NextLoginInfoAction);
            NextOrganizationInfo = new RelayCommand(NextOrganizationInfoAction);
            NextPaymentInfo = new RelayCommand(NextPaymentInfoAction);
            NextPaymentTier = new RelayCommand(NextPaymentTierAction);
            PreviousOrganizationInfo = new RelayCommand(PreviousOrganizationInfoAction);
            PreviousPaymentInfo = new RelayCommand(PreviousPaymentInfoAction);
            PreviousPaymentTier = new RelayCommand(PreviousPaymentTierAction);
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

        private void ValidatePassword(string field)
        {
            ValidateEmpty(field);

            if (field.Length < 3)
                throw new Exception("Password mora sadrzavati najmanje 3 karaktera");

            if (!field.Any(char.IsDigit) || !field.Any(char.IsUpper) || field.All(char.IsLetterOrDigit))
                throw new Exception("Password mora sadrzavati barem jedan broj i barem jedno veliko slovo i barem jedan karakter (trolololo)");
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

        private async void NextLoginInfoAction()
        {
            try
            {
                ValidateEmpty(Username);
                ValidatePassword(Password);
                ValidateEmpty(Email);
                ValidateEmail();
                _navigation.Navigate(typeof(OwnerRegistrationOrganizationInfo), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }
        
        private async void NextOrganizationInfoAction()
        {
            try
            {
                ValidateEmpty(OwnerName);
                ValidateEmpty(OrganizationName);
                ValidateEmpty(Info);
                _navigation.Navigate(typeof(OwnerRegistrationPaymentInfo), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private void PreviousOrganizationInfoAction()
        {
            _navigation.Navigate(typeof(OwnerRegistrationLoginData), this);
        }

        private async void NextPaymentInfoAction()
        {
            try
            {
                //Paypal validation
                _navigation.Navigate(typeof(OwnerRegistrationPaymentTier), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private void PreviousPaymentInfoAction()
        {
            _navigation.Navigate(typeof(OwnerRegistrationOrganizationInfo), this);
        }

        private async void NextPaymentTierAction()
        {
            try
            {
                _navigation.Navigate(typeof(OwnerRegistrationSuccess), this);
                Owner owner = new Owner
                {
                    Username = Username,
                    Password = Password,
                    Email = Email,
                    OrganizationName = OrganizationName,
                    Name = OwnerName,
                    Surname = OwnerName,
                };

                owner = await _user.RegisterOwner(owner);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private void PreviousPaymentTierAction()
        {
            _navigation.Navigate(typeof(OwnerRegistrationPaymentInfo), this);
        }

        private async void ChooseTierAction(object parameter)
        {
            int tier = (int)parameter;
            var dialog = new MessageDialog(tier + "", "Greska");
            await dialog.ShowAsync();
        }


    }
}
