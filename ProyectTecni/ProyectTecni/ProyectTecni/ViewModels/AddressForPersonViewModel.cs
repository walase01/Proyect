using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using ProyectTecni.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectTecni.ViewModels
{
    public class AddressForPersonViewModel : BaseViewModel,INavigationAware
    {

        public int idPersona { get; set; }

        public AddressForPersonViewModel(IDatabaseService databaseService, IPageDialogService _dialogService, INavigationService navigationService) : base(databaseService, _dialogService, navigationService)
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            idPersona = parameters.GetValue<int>("idPerson");
        }
    }
}
