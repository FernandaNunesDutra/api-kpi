using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppKpi.viewmodel;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKpi.view
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartPage : ContentPage
	{
	    List<Microcharts.Entry> _teste = new List<Microcharts.Entry>
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

	    public ChartViewModel ViewModel
	    {
	        get => BindingContext as ChartViewModel;
	        set => BindingContext = value;
	    }

        public ChartPage (List<Microcharts.Entry> entries)
		{
			InitializeComponent();
		    ViewModel = new ChartViewModel(entries);
        }
	}
}