using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();
app.UseStaticFiles();
app.UseFastEndpoints(c => { c.Endpoints.RoutePrefix = "api"; }).UseSwaggerGen();

if (!app.Environment.IsDevelopment())
{
    app.MapFallbackToFile("index.html");
}

app.Run();
