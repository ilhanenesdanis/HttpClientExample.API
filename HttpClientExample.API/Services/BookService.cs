using HttpClientExample.API.Models;

namespace HttpClientExample.API.Services;

public sealed class BookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BaseResponse<IReadOnlyList<NewBookResponse>>> GetNewBooks()
    {
        var content = await _httpClient.GetFromJsonAsync<BaseResponse<IReadOnlyList<NewBookResponse>>>("/book/newBook");

        return content ?? new BaseResponse<IReadOnlyList<NewBookResponse>>();
    }
}
