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

            return new List<Microcharts.Entry>
            {
                new Microcharts.Entry(200)
                {
                    Label = "Janeiro",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(250)
                {
                    Label = "Fevereiro",
                    ValueLabel = "250",
                    Color = SKColor.Parse("#68B9C0")
                },
                new Microcharts.Entry(100)
                {
                    Label = "Março",
                    ValueLabel = "100",
                    Color = SKColor.Parse("#90D585")
                },
                new Microcharts.Entry(150)
                {
                    Label = "Abril",
                    ValueLabel = "150",
                    Color = SKColor.Parse("#e77e23")
                }
            };

            var entries = new List<Microcharts.Entry>();

            foreach (var item in items)
            {
                entries.Add(new Microcharts.Entry(200)
                {
                    Label = item.Description,
                    ValueLabel = item.Value,
                    Color = SKColor.Parse("#266489")
                });
            }

            return entries;

        }
    }
}
