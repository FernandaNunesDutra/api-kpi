
using System.Threading.Tasks;
using AppKpi.api;
using AppKpi.dependencyservice;
using AppKpi.service;
using AppKpi.view;

namespace AppKpi.viewmodel.load
{
    class LoadLoginViewModel : BaseViewModel, ILoadViewModel
    {
        private readonly IMessageService _messageService;
        private readonly PageService _pageService;
        private readonly UserService _userService;
        private readonly ApiService _apiService;
        private readonly string _username;
        private readonly string _password;

        public LoadLoginViewModel(IMessageService messageService, PageService pageService, UserService userService, ApiService apiService, string username, string password)
        {
            _messageService = messageService;
            _pageService = pageService;
            _userService = userService;
            _apiService = apiService;
            _username = username;
            _password = password;
        }

        public async Task Load()
        {
            UserService.InitializeLogin(_username, _password);

            var response = await _apiService.ValidateLogin(UserService.LoggedUser);

            if (response.Success)
            {
                await _userService.PersistLogin(response.Data.UserId, response.Data.Name, response.Data.Email, response.Data.Token);

                await _pageService.PushAsyncAndRemoveCurrent(new InitialPage());
            }
            else
            {
                _messageService.ShortAlert(response.ErrorDescription);
                await _pageService.PushAsyncAndRemoveCurrent(new LoginPage());
            }
        }
    }
}
