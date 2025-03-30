using HttpClientExample.API.Endpoints;
using HttpClientExample.API.Options;
using HttpClientExample.API.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddOptions<NewsOptions>().BindConfiguration("NewsApi")
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddHttpClient("books", (serviceProvider, httpclient) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<NewsOptions>>().Value;

    httpclient.DefaultRequestHeaders.Add("authorization", settings.ApiKey);
    httpclient.BaseAddress = new Uri(settings.BaseURL);


}); ;

builder.Services.AddHttpClient<BookService>((serviceProvider, httpclient) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<NewsOptions>>().Value;

    httpclient.DefaultRequestHeaders.Add("authorization", settings.ApiKey);
    httpclient.BaseAddress = new Uri(settings.BaseURL);
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new SocketsHttpHandler()
    {
        PooledConnectionLifetime = TimeSpan.FromMinutes(5),
    };
}).SetHandlerLifetime(Timeout.InfiniteTimeSpan);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapBooksEndpoints();


app.Run();