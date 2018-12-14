using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AppKpi.api;
using AppKpi.api.response.model;
using AppKpi.dependencyservice;
using AppKpi.model;
using AppKpi.service;
using AppKpi.view;
using AppKpi.viewmodel.load;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppKpi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new InitialPage(new List<Group>()));

            //var _pageService = new PageService();
            //var message = DependencyService.Get<IMessageService>();
            //var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            
            //var loadVm = new LoadInitialViewModel(message, _pageService, new UserService(connection), new ApiService(connection));

            //MainPage = new NavigationPage(new LoadPage(loadVm));
        }

        protected override void OnStart()
        {
            base.OnStart();
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            CreateTables(connection);
        }

        private async Task CreateTables(SQLiteAsyncConnection connection)
        {
            await connection.CreateTableAsync<User>();
        }
    }
}
