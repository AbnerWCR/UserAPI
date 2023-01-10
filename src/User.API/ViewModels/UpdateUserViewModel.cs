using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace User.API.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "Id can't be null")]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name can't be null")]
        [MinLength(3, ErrorMessage = "Minimum characters is 3.")]
        [MaxLength(50, ErrorMessage = "Maximum characters is 50.")]
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name can't be null")]
        [MinLength(3, ErrorMessage = "Minimum characters is 3.")]
        [MaxLength(50, ErrorMessage = "Maximum characters is 50.")]
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email can't be null")]
        [MinLength(10, ErrorMessage = "Minimum characters is 10.")]
        [MaxLength(180, ErrorMessage = "Maximum characters is 180.")]
        [RegularExpression(
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "The email is not valid.")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
