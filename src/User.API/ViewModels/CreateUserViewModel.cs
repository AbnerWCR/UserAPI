using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace User.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Name can't be null")]
        [MinLength(3, ErrorMessage = "Minimum characters is 3.")]
        [MaxLength(50, ErrorMessage = "Maximum characters is 50.")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email can't be null")]
        [MinLength(10, ErrorMessage = "Minimum characters is 10.")]
        [MaxLength(180, ErrorMessage = "Maximum characters is 180.")]
        [RegularExpression(
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
            ErrorMessage = "The email is not valid.")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be null")]
        [MinLength(6, ErrorMessage = "Minimum characters is 10.")]
        [MaxLength(18, ErrorMessage = "Maximum characters is 180.")]
        [RegularExpression(
            @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", 
            ErrorMessage = "Your password must contain at least one uppercase, lowercase, number and contain at least one special characters letter.")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
