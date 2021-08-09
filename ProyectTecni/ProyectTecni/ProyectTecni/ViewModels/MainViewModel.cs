using Prism.Commands;
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
    public class MainViewModel : BaseViewModel
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public ICommand InsertPerson { get; set; }
        public ObservableCollection<Person> ListPerson  ()=> new ObservableCollection<Person>(listPerson);

        public MainViewModel(IDatabaseService databaseService,IPageDialogService _dialogService,INavigationService navigationService) : base(databaseService,_dialogService,navigationService)
        {
            InsertPerson = new Command(SaveAddress);
        }


        //public void getData()
        //{
        //    var datos =  listPerson;
        //    foreach (var data in datos)
        //    {
        //        ListPerson.Add(data);
        //    }
        //}

        private async void SaveAddress()
        {
            var parameter = new NavigationParameters();
            

            if (Empty(Name,LastName,Cedula))
            {
                Person person = new Person();             
                person.Name = Name;
                person.LastName = LastName;
                person.Cedula = Cedula;              
                await databaseService.InsertPeople(person);
                parameter.Add("idPerson", person.IdPerson);
                await navigationService.NavigateAsync("AddressForPerson",parameter);
                await dialogService.DisplayAlertAsync("Confirm", "Correctly", "OK");
                
            }
            else
            {
                await dialogService.DisplayAlertAsync("Empty cells", "fill in the cells", "OK");
            }

        }

        public bool Empty(string city, string country,string cedula)
        {
            if (!String.IsNullOrEmpty(city) && !String.IsNullOrEmpty(country) && !String.IsNullOrEmpty(cedula))
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
