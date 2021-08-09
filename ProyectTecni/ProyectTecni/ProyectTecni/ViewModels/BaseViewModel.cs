using Prism.Navigation;
using Prism.Services;
using ProyectTecni.Models;
using ProyectTecni.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProyectTecni.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IPageDialogService dialogService;
        protected IDatabaseService databaseService;
        protected INavigationService navigationService;

        protected List<Person> listPerson = new List<Person>();

        public BaseViewModel(IDatabaseService _databaseService, IPageDialogService _dialogService, INavigationService _navigationService)
        {
            this.databaseService = _databaseService;
            this.dialogService = _dialogService;
            this.navigationService = _navigationService;
            GetData();
        }
        public async void GetData()
        {
            listPerson = await databaseService.GetListPeople();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
