using HttpClientExample.API.Models;
using HttpClientExample.API.Options;
using HttpClientExample.API.Services;
using Microsoft.Extensions.Options;

namespace HttpClientExample.API.Endpoints;

public static class BooksEndpoints
{
    public static void MapBooksEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/newBooks", async (IOptions<NewsOptions> settings) =>
        {
            //var client = new HttpClient();
            var client = new HttpClient(new SocketsHttpHandler());
            //var client = new HttpClient(new HttpClientHandler());


            client.DefaultRequestHeaders.Add("authorization", settings.Value.ApiKey);
            client.BaseAddress = new Uri(settings.Value.BaseURL);

            var content = await client.GetFromJsonAsync<BaseResponse<IReadOnlyList<NewBookResponse>>>("/book/newBook");

            return Results.Ok(content);
        });
        app.MapGet("/v2/newBooks", async (IOptions<NewsOptions> settings, IHttpClientFactory factory) =>
        {

            var client = factory.CreateClient();
            client.DefaultRequestHeaders.Add("authorization", settings.Value.ApiKey);
            client.BaseAddress = new Uri(settings.Value.BaseURL);

            var content = await client.GetFromJsonAsync<BaseResponse<IReadOnlyList<NewBookResponse>>>("/book/newBook");

            return Results.Ok(content);
        });
        app.MapGet("/v3/newBooks", async (IHttpClientFactory factory) =>
        {

            var client = factory.CreateClient("books");

            var content = await client.GetFromJsonAsync<BaseResponse<IReadOnlyList<NewBookResponse>>>("/book/newBook");

            return Results.Ok(content);
        });
        app.MapGet("/v4/newBooks", async (BookService bookService) =>
        {

            var content = await bookService.GetNewBooks();

            return Results.Ok(content);
        });
    }
}
