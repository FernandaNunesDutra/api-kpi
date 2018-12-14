using AppKpi.api;
using AppKpi.api.response.model;
using AppKpi.dependencyservice;
using AppKpi.model;
using AppKpi.service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AppKpi.view;
using AppKpi.viewmodel.load;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace AppKpi.viewmodel
{
    public class InitialViewModel : BaseViewModel
    {
        private IMessageService _messageService;
        private PageService _pageService;
        private ApiService _apiService;
        private List<Group> _groups;

        public ObservableCollection<ListViewGroup<ListViewItem>> Groups { get; set; }

        public InitialViewModel(IMessageService messageService, PageService pageService, ApiService apiService, List<Group> groups)
        {
            Groups = new ObservableCollection<ListViewGroup<ListViewItem>>();

            _messageService = messageService;
            _pageService = pageService;
            _apiService = apiService;
            _groups = groups;

            GoBackCommand = new Command(GoBack);
        }

        public async void Load()
        {
            Groups.Clear();

            var items = new List<GroupItem>
            {
                new GroupItem
                {
                    DashboardId = 1,
                    Current = "15",
                    Indicator = "TESTE 1",
                    General = "10",
                    Type = "1"
                },
                new GroupItem
                {
                    DashboardId = 2,
                    Current = "18",
                    Indicator = "TESTE 2",
                    General = "20",
                    Type = "2"
                },
                new GroupItem
                {
                    DashboardId = 3,
                    Current = "21",
                    Indicator = "TESTE 3",
                    General = "30",
                    Type = "3"
                },
            };

            //foreach (var group in _groups)
            //{
            //Groups.Add(await CreateGroup(group.Description, group.Items));
            Groups.Add(await CreateGroup("ENTRADA", items));
            //}
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
                    General = item.General,
                    Current = item.Current
                });
            }

            return group;
        }

        private async void GetDetailKpi(ListViewItem item)
        {
            var loadVm = new LoadChartViewModel(_messageService, _pageService, _apiService, item.Id.Value);
            await _pageService.PushAsyncAndRemoveCurrent(new LoadPage(loadVm));
        }

        private async void GoBack()
        {
            await _pageService.PopAsync();
        }
    }
}
