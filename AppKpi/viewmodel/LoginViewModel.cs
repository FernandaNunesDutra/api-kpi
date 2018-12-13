using System.Windows.Input;

namespace AppKpi.viewmodel
{
    public class LoginViewModel : BaseViewModel
    {
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
        private async void VerifyLogin()
        {
            var loadVm = new LoadLoginViewModel(_pageService, _messageService, _userService, _username, _password);
            await _pageService.PushAsyncAndRemoveCurrent(new LoadPage(loadVm));
        }
    }
}
