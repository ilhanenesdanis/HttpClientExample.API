using HttpClientExample.API.Models;
using HttpClientExample.API.Options;
using Microsoft.Extensions.Options;

namespace HttpClientExample.API.Endpoints;

public static class BooksEndpoints
{
    public static void MapBooksEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/newBooksBadWay", async (IOptions<NewsOptions> settings) =>
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("authorization", settings.Value.ApiKey);
            client.BaseAddress = new Uri(settings.Value.BaseURL);

            var content = await client.GetFromJsonAsync<BaseResponse<IReadOnlyList<NewBookResponse>>>("/book/newBook");

            return Results.Ok(content);
        });
    }
}
