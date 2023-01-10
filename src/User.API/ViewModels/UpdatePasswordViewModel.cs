using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace User.API.ViewModels
{
    public class UpdatePasswordViewModel
    {
        [Required(ErrorMessage = "Id can't be null")]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Email can't be null")]
        [MinLength(10, ErrorMessage = "Minimum characters is 10.")]
        [MaxLength(180, ErrorMessage = "Maximum characters is 180.")]
        [RegularExpression(
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "The email is not valid.")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can't be null")]
        [MinLength(6, ErrorMessage = "Minimum characters is 6.")]
        [MaxLength(18, ErrorMessage = "Maximum characters is 18.")]
        [RegularExpression(
            @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Your password must contain at least one uppercase, lowercase, number and contain at least one special characters letter.")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
