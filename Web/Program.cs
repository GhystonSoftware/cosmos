using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();
app.UseFastEndpoints(c => { c.Endpoints.RoutePrefix = "api"; }).UseSwaggerGen();
app.Run();
