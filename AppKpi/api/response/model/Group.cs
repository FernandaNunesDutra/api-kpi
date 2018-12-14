using System.Collections.Generic;
using AppKpi.model;
using Newtonsoft.Json;

namespace AppKpi.api.response.model
{
    public class Group
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("items")]
        public List<GroupItem> Items{ get; set; }
    }
}
