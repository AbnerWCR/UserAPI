using Newtonsoft.Json;
using System;

namespace User.Domain.DTOs
{
    public abstract class BaseDto 
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
