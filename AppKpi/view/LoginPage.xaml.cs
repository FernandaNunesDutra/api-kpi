
using AppKpi.api;
using AppKpi.dependencyservice;
using AppKpi.service;
using AppKpi.viewmodel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKpi.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
	    public LoginViewModel ViewModel
	    {
	        get => BindingContext as LoginViewModel;
	        set => BindingContext = value;
	    }

        public LoginPage()
	    {
	        InitializeComponent();

            
	        var connection = DependencyService.Get<ISQLiteDb>().GetConnection();
	        var message = DependencyService.Get<IMessageService>();
            var userService = new UserService(connection);

	        ViewModel = new LoginViewModel(message, new PageService(), userService, new ApiService(connection));
	    }
    }
}