using Newtonsoft.Json;

namespace AppKpi.model
{
    public class GroupItem
    {
        [JsonProperty("cod")]
        public int DashboardId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("indicator")]
        public string Indicator { get; set; }

        [JsonProperty("general")]
        public decimal General { get; set; }

        [JsonProperty("current")]
        public decimal Current { get; set; }
    }
}
