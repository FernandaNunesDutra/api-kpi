using System.Collections.Generic;
using AppKpi.api;
using AppKpi.api.response.model;
using AppKpi.dependencyservice;
using AppKpi.model;
using AppKpi.service;
using AppKpi.viewmodel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKpi.view
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InitialPage : ContentPage
	{
	    public InitialViewModel ViewModel
	    {
	        get => BindingContext as InitialViewModel;
	        set => BindingContext = value;
	    }

        public InitialPage (List<Group> groups)
		{
			InitializeComponent ();
		    var message = DependencyService.Get<IMessageService>();

		    ViewModel = new InitialViewModel(message, new PageService(), groups);
        }

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
            ViewModel.Load();
	    }
	}
}