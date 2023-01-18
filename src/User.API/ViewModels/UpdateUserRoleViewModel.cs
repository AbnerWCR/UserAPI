using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace User.API.ViewModels
{
    public class UpdateUserRoleViewModel
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

        //[Required(ErrorMessage = "Role can't be null")]
        //[MinLength(5, ErrorMessage = "Minimum characters is 5.")]
        //[MaxLength(6, ErrorMessage = "Maximum characters is 6.")]
        //[RegularExpression(@"([A-Z])", ErrorMessage = "Role should only take letters in upper case")]
        //[JsonProperty(PropertyName = "role")]
        //public string Role { get; set; }
    }
}
