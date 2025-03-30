using System.Text.Json.Serialization;

namespace HttpClientExample.API.Models;

public sealed class NewBookResponse
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
    [JsonPropertyName("indirim")]
    public string Discount { get; set; }
    [JsonPropertyName("fiyat")]
    public string Price { get; set; }
    [JsonPropertyName("yayın")]
    public string Publication { get; set; }
    [JsonPropertyName("yazar")]
    public string Writer { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("image")]
    public string Image { get; set; }
}
