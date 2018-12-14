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
	    public ChartViewModel ViewModel
	    {
	        get => BindingContext as ChartViewModel;
	        set => BindingContext = value;
	    }

        public ChartPage (List<Microcharts.Entry> entries)
		{
			InitializeComponent();
		    ViewModel = new ChartViewModel(entries, ChartType.BAR);
        }

	    protected override bool OnBackButtonPressed()
	    {
	        if (ViewModel.GoBackCommand != null)
	            ViewModel.GoBackCommand.Execute(null);
	        else
	            return base.OnBackButtonPressed();

	        return true;
	    }
    }
}