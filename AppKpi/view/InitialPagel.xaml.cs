using AppKpi.api.response.model;
using AppKpi.dependencyservice;
using AppKpi.service;
using AppKpi.viewmodel;
using System.Collections.Generic;
using AppKpi.api;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKpi.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitialPage : BasePage<InitialViewModel>
    {
        public InitialPage(List<Group> groups)
        {
            InitializeComponent();
            var message = DependencyService.Get<IMessageService>();
            var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            ViewModel = new InitialViewModel(message, new PageService(), new ApiService(connection), groups);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Load();
        }
    }
}