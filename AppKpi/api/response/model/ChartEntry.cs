using System.Collections.Generic;
using AppKpi.model;
using Newtonsoft.Json;

namespace AppKpi.api.response.model
{
    public class ChartEntry
    {
        [JsonProperty("label")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
