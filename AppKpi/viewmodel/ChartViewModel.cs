using System;
using System.Collections.Generic;
using AppKpi.dependencyservice;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace AppKpi.viewmodel
{
    public enum ChartType
    {
        BAR,
        DONUT,
        LINE,
        POINT,
        RADIAL
    }

    public class ChartViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        public Chart Chart { get; set; }
        public string Name { get; set; }
        public ChartViewModel(List<Microcharts.Entry> entries, ChartType type, IPageService pageService, string name)
        {
            Name = name;
            Chart = ChooseChart(type, entries);
            GoBackCommand = new Command(GoBack);
            _pageService = pageService;
        }

        private Chart ChooseChart(ChartType type, List<Microcharts.Entry> entries)
        {
            switch (type)
            {
                case ChartType.BAR:
                    return new BarChart()
                    {
                        Entries = entries,
                        LabelTextSize = 35,
                        BackgroundColor = SKColors.Transparent,
                        BarAreaAlpha = Byte.Parse("1"),
                    };
                    break;
                case ChartType.DONUT:
                    return new DonutChart()
                    {
                        Entries = entries,
                        LabelTextSize = 35,
                        BackgroundColor = SKColors.Transparent,
                    };
                    break;
                case ChartType.LINE:
                    return new LineChart()
                    {
                        Entries = entries,
                        LabelTextSize = 35,
                        BackgroundColor = SKColors.Transparent,
                    };
                    break;
                case ChartType.POINT:
                    return new PointChart()
                    {
                        Entries = entries,
                        LabelTextSize = 35,
                        BackgroundColor = SKColors.Transparent,
                    };
                    break;
                case ChartType.RADIAL:
                    return new RadialGaugeChart()
                    {
                        Entries = entries,
                        LabelTextSize = 35,
                        BackgroundColor = SKColors.Transparent,
                    };
                    break;
            }

            return null;
        }

        private async void GoBack()
        {
            await _pageService.PopAsync();
        }
    }
}
