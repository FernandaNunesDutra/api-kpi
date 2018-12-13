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
        [JsonProperty("nome")]
        public string Name { get; set; }

        [Column("usuario")]
        [JsonProperty("usuario")]
        public string Email { get; set; }

        [Ignore]
        [JsonProperty("senha")]
        public string Password { get; set; }

        [Column("token")]
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
