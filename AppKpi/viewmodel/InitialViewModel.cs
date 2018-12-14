using AppKpi.api;
using AppKpi.api.response.model;
using AppKpi.dependencyservice;
using AppKpi.model;
using AppKpi.service;
using AppKpi.view;
using AppKpi.viewmodel.load;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppKpi.viewmodel
{
    public class InitialViewModel : BaseViewModel
    {
        private IMessageService _messageService;
        private PageService _pageService;
        private ApiService _apiService;
        private List<Group> _groups;

        public string Company { get; set; }
        public ObservableCollection<ListViewGroup<ListViewItem>> Groups { get; set; }
        public ICommand LogoutCommand { get; private set; }

        public InitialViewModel(IMessageService messageService, PageService pageService, ApiService apiService, List<Group> groups)
        {
            Company = "CD Cremer";
            Groups = new ObservableCollection<ListViewGroup<ListViewItem>>();

            _messageService = messageService;
            _pageService = pageService;
            _apiService = apiService;
            _groups = groups;

            GoBackCommand = new Command(GoBack);
            LogoutCommand = new Command(Logout);
        }

        public async void Load()
        {
            Groups.Clear();

            foreach (var group in _groups)
            {
                Groups.Add(await CreateGroup(group.Description, group.Items));
            }
        }

        private async Task<ListViewGroup<ListViewItem>> CreateGroup(string description, List<GroupItem> items)
        {

            var command = new Command<ListViewItem>(GetDetailKpi);

            var group = new ListViewGroup<ListViewItem>
            {
                GroupTitle = description,
            };

            foreach (var item in items)
            {

                group.Add(new ListViewItem
                {
                    Id = item.DashboardId,
                    Title = item.Indicator,
                    ItemCommand = command,
                    General = string.Format("{0:N}", item.General),
                    Current = string.Format("{0:N}", item.Current)
                });
            }

            return group;
        }

        private async void GetDetailKpi(ListViewItem item)
        {
            var loadVm = new LoadChartViewModel(_messageService, _pageService, _apiService, item.Id.Value, item.Title);
            await _pageService.PushAsync(new LoadPage(loadVm));
        }

        private async void Logout()
        {
           await _pageService.PushAsyncAndRemoveCurrent(new LoginPage());
        }

        private void GoBack()
        {
            //_pageService.PopAsync();
        }
    }
}
