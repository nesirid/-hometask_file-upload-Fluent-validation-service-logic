using eLearning.Helpers.Extensions;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCustomServices(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCustomMiddlewares(app.Environment);

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseCustomEndpoints();
});

app.Run();
