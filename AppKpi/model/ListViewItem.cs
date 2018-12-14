using System.Windows.Input;

namespace AppKpi.model
{
    public class ListViewItem
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Current { get; set; }
        public string General { get; set; }
        public string Detail { get; set; }
        public ICommand ItemCommand { get; set; }
    }
}
