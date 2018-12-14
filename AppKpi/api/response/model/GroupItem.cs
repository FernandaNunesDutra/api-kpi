using Newtonsoft.Json;
using SQLite;

namespace AppKpi.model
{
    public class GroupItem
    {
        [JsonProperty("cod_dashboard")]
        public int DashboardId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("indicator")]
        public string Indicator { get; set; }

        [JsonProperty("general")]
        public string General { get; set; }

        [JsonProperty("current")]
        public string Current { get; set; }
    }
}
