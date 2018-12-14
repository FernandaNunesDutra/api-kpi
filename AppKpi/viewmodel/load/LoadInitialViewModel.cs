
using System.Threading.Tasks;
using AppKpi.api;
using AppKpi.dependencyservice;
using AppKpi.service;
using AppKpi.view;

namespace AppKpi.viewmodel.load
{
    public class LoadInitialViewModel : BaseViewModel, ILoadViewModel
    {
        private readonly IMessageService _messageService;
        private readonly PageService _pageService;
        private readonly ApiService _apiService;
        private int _todos;

        public LoadInitialViewModel(IMessageService messageService, PageService pageService, UserService userService, ApiService apiService)
        {
            _messageService = messageService;
            _pageService = pageService;
            _apiService = apiService;
            _todos = 0;
        }

        public async Task Load()
        {
            var response = await _apiService.GetDashboard(_todos);

            if (response.Success)
            {
                await _pageService.PushAsyncAndRemoveCurrent(new InitialPage(response.Data));
            }
            else
            {
                _messageService.ShortAlert(response.ErrorDescription);
                await _pageService.PushAsyncAndRemoveCurrent(new LoginPage());
            }
        }
    }
}
