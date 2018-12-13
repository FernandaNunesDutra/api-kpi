using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AppKpi.api.response
{
    public class GenericResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}
