using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppKpi.api;
using AppKpi.service;
using AppKpi.view;

namespace AppKpi.viewmodel.load
{
    class LoadLoginViewModel : BaseViewModel, ILoadViewModel
    {
        private readonly UserService _userService;
        private readonly ApiService _apiService;
        private readonly string _username;
        private readonly string _password;

        public LoadLoginViewModel(UserService userService, ApiService apiService, string username, string password)
        {
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

                var pageVm = new LoadSelectBranchViewModel(_pageService, user.OrganizationId, true);
                await _pageService.PushAsyncAndRemoveCurrent(new LoadPage(pageVm, LoadPage.Background.WHITE));
            }
            else if (response.LoginAgain)
            {
                await _pageService.RequireLogin();
            }
            else
            {
                _messageService.ShortAlert(response.ErrorDescription);
                await _pageService.PushAsyncAndRemoveCurrent(new LoginPage());
            }
        }
    }
}
