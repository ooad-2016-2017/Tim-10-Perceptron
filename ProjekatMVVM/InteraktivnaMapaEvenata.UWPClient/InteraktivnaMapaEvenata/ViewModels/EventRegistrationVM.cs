using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Registration;
using InteraktivnaMapaEvenata.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace InteraktivnaMapaEvenata.ViewModels {
    public class EventRegistrationVM : BindableBase {
        #region services
        INavigationService _navigation;
        IEventService _event;
        #endregion

        #region Binding
        private string name;
        private TimeSpan startTime;
        private TimeSpan finishTime;
        private string info;
        private string tags;
        private Double latitude;
        private Double longitude;
        private bool hasPromotion;
        private string promotionInfo;

        public string Name
        {
            get { return name; }
            set { this.SetProperty(ref this.name, value); }
        }

        public TimeSpan StartTime
        {
            get { return startTime; }
            set { this.SetProperty(ref this.startTime, value); }
        }

        public TimeSpan FinishTime
        {
            get { return finishTime; }
            set { this.SetProperty(ref this.finishTime, value); }
        }

        public string Info
        {
            get { return name; }
            set { this.SetProperty(ref this.name, value); }
        }

        public string Tags
        {
            get { return tags; }
            set { this.SetProperty(ref this.tags, value); }
        }

        public Double langitude
        {
            get { return langitude; }
            set { this.SetProperty(ref this.longitude, value); }
        }

        public Double lattitude 
        {
            get { return langitude; }
            set { this.SetProperty(ref this.latitude, value); }
        }

        public bool HasPromotion
        {
            get { return hasPromotion; }
            set { this.SetProperty(ref this.hasPromotion, value); }
        }

        public string PromotionInfo
        {
            get { return promotionInfo; }
            set { this.SetProperty(ref this.promotionInfo, value); }
        }

        #endregion

        #region ViewModels
        #endregion

        #region Commands
        public ICommand NextData { get; set; }
        public ICommand NextLocation { get; set; }
        public ICommand NextPromotion { get; set; }
        public ICommand BackToMainPage { get; set; }
        #endregion


        public EventRegistrationVM(IEventService _event, INavigationService navigation)
        {

            this._navigation = navigation;
            this._event = _event;
            NextData = new RelayCommand(NextDataAction);
            NextLocation = new RelayCommand(NextLocationAction);
            NextPromotion = new RelayCommand(NextPromotionAction);
           // BackToMainPage = new RelayCommand(BackToMainPageAction);
            //ChooseTier = new RelayCommand(ChooseTierAction);
        }

        // TODO: Handle network errors

        private void ValidateEmpty(string field)
        {
            if (field == null || field == "")
                throw new Exception("Prazno polje");
        }

        private void ValidateDate()
        {
            if(startTime > finishTime)
            {
                throw new Exception("Pocetak ne moze biti poslije kraja");
            }
            if(startTime < TimeSpan.Zero)
            {
                throw new Exception("Event morate kreirati prije pocetka");
            }
        }

        private async void NextDataAction()
        {
            try
            {
                ValidateEmpty(Name);
                ValidateEmpty(Info);
                ValidateEmpty(Tags);
                _navigation.Navigate(typeof(EventCreationLocation), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private async void NextLocationAction()
        {
            try
            {
                _navigation.Navigate(typeof(EventCreationPromotion), this);
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }

        private async void NextPromotionAction()
        {
            try
            {
                _navigation.Navigate(typeof(MainPage));
            }
            catch (Exception e)
            {
                var dialog = new MessageDialog(e.Message, "Greska");
                await dialog.ShowAsync();
            }
        }
    }
}
