using System.Text.Json.Serialization;

namespace HttpClientExample.API.Models
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("result")]
        public T Result { get; set; }
    }
}
