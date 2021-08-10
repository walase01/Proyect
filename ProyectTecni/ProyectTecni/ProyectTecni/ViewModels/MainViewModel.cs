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
        public  string Title => "OrionTek - People";
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public ICommand InsertPerson { get; set; }
        public ObservableCollection<Person> ListPerson { get; set; }
        public MainViewModel(IDatabaseService databaseService,IPageDialogService _dialogService,INavigationService navigationService) : base(databaseService,_dialogService,navigationService)
        {
            InsertPerson = new Command(SavePerson);
            GetData();
        }

        private async void GetData()
        {
            try
            {
                ListPerson = new ObservableCollection<Person>(await databaseService.GetListPeople());
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        private async void SavePerson()
        {
            var parameter = new NavigationParameters();


            if (Empty(Name, LastName, Cedula))
            {
                Person person = new Person();
                person.Name = Name;
                person.LastName = LastName;
                person.Cedula = Cedula;
                await databaseService.InsertPeople(person);
                GetData();
                parameter.Add("idPerson", person.IdPerson);
                await navigationService.NavigateAsync($"{NvigatonConst.Address}", parameter);
                await dialogService.DisplayAlertAsync("Confirm", "Correctly", "OK");

            }
            else
            {
                await dialogService.DisplayAlertAsync("Empty cells", "fill in the cells", "OK");
            }

        }

        public bool Empty(string name, string lastname,string cedula)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(lastname) && !String.IsNullOrEmpty(cedula))
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
