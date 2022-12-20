using Newtonsoft.Json;

namespace User.API.ViewModels
{
    public class ResultViewModel
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "data")]
        public dynamic Data { get; set; }

        public ResultViewModel()
        {

        }

        public ResultViewModel(string message, bool success, dynamic data)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
