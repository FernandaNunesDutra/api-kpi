using AppKpi.viewmodel;
using Xamarin.Forms;

namespace AppKpi.view
{
    public class BasePage<TViewModel> : ContentPage
        where TViewModel : BaseViewModel
    {
        public TViewModel ViewModel
        {
            get => BindingContext as TViewModel;
            set => BindingContext = value;
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
