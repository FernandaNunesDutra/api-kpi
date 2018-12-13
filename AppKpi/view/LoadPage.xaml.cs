using AppKpi.viewmodel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKpi.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadPage : ContentPage
	{

	    private ILoadViewModel ViewModel
	    {
	        get => BindingContext as ILoadViewModel;
	        set => BindingContext = value;
	    }

	    public LoadPage(ILoadViewModel viewModel)
	    {
	        ViewModel = viewModel;
	        InitializeComponent();
	    }

	    protected async override void OnAppearing()
	    {
	        base.OnAppearing();
	        await ViewModel.Load();
	    }
	}
}