using Newtonsoft.Json;
using User.Domain.DTOs;

namespace User.Services.DTOs
{
    public class UserDTO : BaseDto
    {   
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
    }
}
