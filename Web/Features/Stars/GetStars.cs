using System.Net;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Web.Database;

namespace Web.Features.Stars;

public class GetStars
{
    public record Request(int Id);
    
    public record Response(IEnumerable<Star> Stars, IEnumerable<Constellation> Constellations);

    public record StarJson(Star[] Stars);
    
    public record Star(
        string Id,
        decimal Longitude,
        decimal Latitude,
        decimal Brightness
    );

    public record Line(
        string Id,
        Star Star1,
        Star Star2
    );

    public record Constellation(
        string Id,
        string PlanetId,
        string Name,
        IEnumerable<Line> Lines
    );
    
    public class Endpoint(DataContext dataContext) : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("/stars/{Id}");
            AllowAnonymous();
        }

        public override async Task<Response> ExecuteAsync(Request request, CancellationToken ct)
        {
            var planet = await dataContext.Planets.Include(p => p.StarMaps)!.ThenInclude(starMap => starMap.VisibleStars).SingleOrDefaultAsync(p => p.Id == request.Id, ct);

            if (planet == null)
            {
                ThrowError("Planet not found", (int)HttpStatusCode.NotFound);
            }


            var visibleStars = planet.NavProps().StarMaps.SingleOrDefault()?.NavProps().VisibleStars.Select(star => new Star(
                star.Id.ToString(),
                star.Longitude,
                star.Latitude,
                star.Brightness
            )) ?? [];


            // TODO: load the stars using the planet's VisibleStars
            

            return new Response(visibleStars, []);
        }
    }
}
