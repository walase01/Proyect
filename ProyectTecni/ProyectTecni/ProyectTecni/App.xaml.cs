using Prism;
using Prism.Ioc;
using Prism.Unity;
using ProyectTecni.Services;
using ProyectTecni.ViewModels;
using ProyectTecni.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectTecni
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base (initializer)
        {
        }

        protected async override void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{NvigatonConst.navigation}/{NvigatonConst.Person}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IDatabaseService, DabaseService>();

            containerRegistry.RegisterInstance<IDatabaseService>(new DatabaseService());

            containerRegistry.RegisterForNavigation<NavigationPage>(NvigatonConst.navigation);
            containerRegistry.RegisterForNavigation<MainPage,MainViewModel>(NvigatonConst.Person);
            containerRegistry.RegisterForNavigation<AddressForPerson , AddressForPersonViewModel>(NvigatonConst.Address);
        }
    }
}
