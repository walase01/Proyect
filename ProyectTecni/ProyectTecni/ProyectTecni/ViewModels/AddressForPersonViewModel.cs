using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using ProyectTecni.Models;
using ProyectTecni.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectTecni.ViewModels
{
    public class AddressForPersonViewModel : BaseViewModel, INavigationAware
    {
        public string Title => "OrionTek - Address for people";
        public string City { get; set; }
        public string Country { get; set; }
        public int idPersona { get; set; }
        public ICommand InsertAddress { get; set; }
        public ObservableCollection<Address> ListAddress { get; set; }

        public AddressForPersonViewModel(IDatabaseService databaseService, IPageDialogService _dialogService, INavigationService navigationService) : base(databaseService, _dialogService, navigationService)
        {
            InsertAddress = new Command(SaveAddress);
            getData();
        }

        public async void getData()
        {
            try
            {
                ListAddress = new ObservableCollection<Address>(await databaseService.GetAddresses());
            }
            catch (Exception ex)
            {

            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            idPersona = parameters.GetValue<int>("idPerson");
        }

        public async void SaveAddress()
        {
            if (Empty(City, Country))
            {
                Address address = new Address();
                address.IdPerson = idPersona;
                address.City = City;
                address.Country = Country;
                await databaseService.InsertAddress(address);
                getData();
                await dialogService.DisplayAlertAsync("Correct", "your data was saved correctly", "Ok");
            }
            else
            {
                await dialogService.DisplayAlertAsync("Empty cells", "fill in the cells", "OK");
            }
        }

        public bool Empty(string city, string country)
        {
            if (!String.IsNullOrEmpty(city) && !String.IsNullOrEmpty(country))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
