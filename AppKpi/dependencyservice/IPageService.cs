using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppKpi.dependencyservice
{
    public interface IPageService
    {
        Page Page { get; }
        Task PushAsync(Page page);
        Task PushAsyncAndRemoveCurrent(Page page);
        Task PopAsync();
        Task DisplayAlert(string title, string message, string cancel, bool requiresAttention = false, bool isError = false);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel, bool requiresAttention = false, bool isError = false);
        void ClearNavigationStack();
        void RemovePages(int num);
    }
}
