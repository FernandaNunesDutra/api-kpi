using Newtonsoft.Json;

namespace AppKpi.api.response.model
{
    public class ChartEntry
    {
        [JsonProperty("provider")]
        public string Description { get; set; }

        [JsonProperty("percentage")]
        public string Value { get; set; }
    }
}
