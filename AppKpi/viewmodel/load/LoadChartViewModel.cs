using System.Collections.Generic;
using System.Threading.Tasks;
using AppKpi.api;
using AppKpi.api.response.model;
using AppKpi.dependencyservice;
using AppKpi.service;
using AppKpi.view;
using SkiaSharp;

namespace AppKpi.viewmodel.load
{
    public class LoadChartViewModel : BaseViewModel, ILoadViewModel
    {
        private readonly IMessageService _messageService;
        private readonly PageService _pageService;
        private readonly ApiService _apiService;
        private int _idChart;

        public LoadChartViewModel(IMessageService messageService, PageService pageService, ApiService apiService, int idChart)
        {
            _messageService = messageService;
            _pageService = pageService;
            _apiService = apiService;
            _idChart = idChart;
        }

        public async Task Load()
        {
            var response = await _apiService.GetChartData(_idChart);

            if (response.Success)
            {
                await _pageService.PushAsyncAndRemoveCurrent(new ChartPage(ToMicrochartEntry(response.Data)));
            }
            else
            {
                _messageService.ShortAlert(response.ErrorDescription);
                await _pageService.PopAsync();
            }
        }


        private List<Microcharts.Entry> ToMicrochartEntry(List<ChartEntry> items)
        {
            var entries = new List<Microcharts.Entry>();

            foreach (var item in items)
            {
                var value = int.Parse(decimal.Parse(item.Value).ToString());
                entries.Add(new Microcharts.Entry(value)
                {
                    Label = item.Description,
                    ValueLabel = value.ToString(),
                    Color = SKColor.Parse("#266489")
                });
            }

            return entries;

        }
    }
}
