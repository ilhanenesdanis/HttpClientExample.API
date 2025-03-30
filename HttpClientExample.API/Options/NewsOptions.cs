using System.ComponentModel.DataAnnotations;

namespace HttpClientExample.API.Options;

public sealed class NewsOptions
{
    [Required]
    public string ApiKey { get; set; }
    [Required]
    public string BaseURL { get; set; }
}
