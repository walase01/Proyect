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

        protected List<Person> listPerson = new List<Person>();

        public BaseViewModel(IDatabaseService _databaseService, IPageDialogService _dialogService)
        {
            this.databaseService = _databaseService;
            this.dialogService = _dialogService;

        }
        public async void GetData()
        {
            listPerson = await databaseService.GetListPeople();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
