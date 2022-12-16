using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace User.API.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Login can't be null")]
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password can't be null")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
