using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Web.Database;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");
Console.WriteLine(connectionString);
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();
app.UseStaticFiles();
app.UseFastEndpoints(c => { c.Endpoints.RoutePrefix = "api"; }).UseSwaggerGen();

if (!app.Environment.IsDevelopment())
{
    app.MapFallbackToFile("index.html");
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

app.Run();
