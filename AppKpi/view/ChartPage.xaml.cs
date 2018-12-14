using AppKpi.service;
using AppKpi.viewmodel;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;

namespace AppKpi.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartPage : BasePage<ChartViewModel>
	{	public ChartPage (List<Microcharts.Entry> entries, string name)
		{
			InitializeComponent();
		    ViewModel = new ChartViewModel(entries, ChartType.LINE, new PageService(), name);
        }
    }
}