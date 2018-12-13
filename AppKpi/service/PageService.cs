using AppKpi.service.interfaceservice;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppKpi.service
{
    public class PageService : IPageService
    {
        public Page Page => Application.Current.MainPage;

        public Task DisplayAlert(string title, string message, string cancel, bool requiresAttention = false, bool isError = false)
        {

            return Page.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel, bool requiresAttention = false, bool isError = false)
        {
            return Page.DisplayAlert(title, message, accept, cancel);
        }

        public void RemovePages(int num)
        {
            var existingPages = Page?.Navigation.NavigationStack.ToList();

            if (existingPages != null)
            {

                for (int index = existingPages.Count() - 2; index >= 0; index--)
                {
                    if (num == 0) return;

                    var p = existingPages[index];
                    Page.Navigation.RemovePage(p);
                    num--;
                }
            }
        }

        public Task PopAsync()
        {
            return Page.Navigation.PopAsync();
        }

        public Task PushAsync(Page page)
        {
            return Page.Navigation.PushAsync(page);
        }

        public void ClearNavigationStack()
        {
            var existingPages = Page?.Navigation.NavigationStack.ToList();

            if (existingPages != null)
            {
                for (int index = existingPages.Count() - 2; index >= 0; index--)
                {
                    var p = existingPages[index];

                    Page.Navigation.RemovePage(p);
                }
            }
        }
        public async Task PushAsyncAndRemoveCurrent(Page page)
        {
            await PushAsync(page);
            if (Page.Navigation.NavigationStack.Count > 1)
            {
                Page.Navigation.RemovePage(Page.Navigation.NavigationStack[Page.Navigation.NavigationStack.Count - 2]);
            }
        }

        //public async Task RequireLogin()
        //{
        //    await DisplayAlert(AppResources.Lbl_Information, AppResources.Lbl_LoginAgain, AppResources.Lbl_Ok);
        //    await PushAsync(new LoginPage());
        //    ClearNavigationStack();
        //}

        //public async Task<string> DisplayActionSheet(string title, string[] buttons, string cancel = null, string destruction = null)
        //{
        //    if (cancel == null)
        //        cancel = AppResources.Lbl_Cancel;

        //    return await Page.DisplayActionSheet(title, cancel, destruction, buttons);
        //}
    }
}
