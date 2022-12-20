using Newtonsoft.Json;
using System;

namespace User.Services.DTOs
{
    public class UserDTO 
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
