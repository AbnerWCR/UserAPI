using Newtonsoft.Json;
using System;

namespace User.Domain.DTOs
{
    public abstract class BaseDTO 
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
