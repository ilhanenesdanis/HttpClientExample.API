using HttpClientExample.API.Endpoints;
using HttpClientExample.API.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.Configure<NewsOptions>(builder.Configuration.GetSection("NewsApi"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapBooksEndpoints();


app.Run();