using System.Net;
using System.Text.Json;
using FastEndpoints;
using Web.Database;

namespace Web.Features.Stars;

public class GetStars
{
    public record Request(int Id);
    
    public record Response(IEnumerable<Star> Stars);

    public record StarJson(Star[] Stars);
    
    public record Star(
        string Id,
        float X,
        float Y,
        float Brightness);
    
    public class Endpoint(DataContext dataContext) : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("/stars/{Id}");
            AllowAnonymous();
        }

        public override async Task<Response> ExecuteAsync(Request request, CancellationToken ct)
        {
            var planet = await dataContext.Planets.FindAsync([request.Id], ct);

            if (planet == null)
            {
                ThrowError("Planet not found", (int)HttpStatusCode.NotFound);
            }
            
            // TODO: load the stars using the planet's VisibleStars
            
            var starJson = await JsonSerializer.DeserializeAsync<StarJson>(File.OpenRead("client-app/src/data/stars.json"), cancellationToken: ct);

            return new Response(starJson?.Stars ?? []);
        }
    }
}