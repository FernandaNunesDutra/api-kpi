using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppKpi.model
{
    public class ListViewGroup<T> : ObservableCollection<T>
    {
        public string GroupTitle { get; set; }
        public ICommand GroupCommand { get; set; }
        public string Image { get; set; }
    }
}
