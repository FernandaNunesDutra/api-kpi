using System.Collections.Generic;
using Microcharts;

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

    public class ChartViewModel
    {
        public Chart Chart { get; set; }

        public ChartViewModel(List<Microcharts.Entry> entries, ChartType type)
        {
            Chart = ChooseChart(type, entries);
        }

        private Chart ChooseChart(ChartType type, List<Microcharts.Entry> entries)
        {
            switch (type)
            {
                case ChartType.BAR:
                    return new BarChart() { Entries = entries };
                    break;
                case ChartType.DONUT:
                    return new DonutChart() { Entries = entries };
                    break;
                case ChartType.LINE:
                    return new LineChart() { Entries = entries };
                    break;
                case ChartType.POINT:
                    return new PointChart() { Entries = entries };
                    break;
                case ChartType.RADIAL:
                    return new RadialGaugeChart() { Entries = entries };
                    break;
            }

            return null;
        }
    }
}
