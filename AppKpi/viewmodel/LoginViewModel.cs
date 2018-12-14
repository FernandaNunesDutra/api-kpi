using System.Windows.Input;
using AppKpi.api;
using AppKpi.dependencyservice;
using AppKpi.service;
using AppKpi.view;
using AppKpi.viewmodel.load;
using Xamarin.Forms;

namespace AppKpi.viewmodel
{
    public class LoginViewModel : BaseViewModel
    {
        private IMessageService _messageService;
        private PageService _pageService;
        private UserService _userService;
        private ApiService _apiService;

        private string _username;
        public string Username
        {
            get => _username;
            set => SetValue(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetValue(ref _password, value);
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel(IMessageService messageService, PageService pageService, UserService userService, ApiService apiService)
        {
            _messageService = messageService;
            _pageService = pageService;
            _userService = userService;
            _apiService = apiService;

            LoginCommand = new Command(VerifyLogin);
        }

        private async void VerifyLogin()
        {
            var loadVm = new LoadLoginViewModel(_messageService, _pageService, _userService, _apiService, _username, _password);
            await _pageService.PushAsyncAndRemoveCurrent(new LoadPage(loadVm));
        }
    }
}
