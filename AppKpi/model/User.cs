using Newtonsoft.Json;
using SQLite;

namespace AppKpi.model
{
    public class User
    {
        [PrimaryKey, Column("id")]
        [JsonProperty("id")]
        public int UserId { get; set; }

        [Column("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Column("user")]
        [JsonProperty("usuario")]
        public string Login { get; set; }

        [Ignore]
        [JsonProperty("senha")]
        public string Password { get; set; }

        [Column("token")]
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
