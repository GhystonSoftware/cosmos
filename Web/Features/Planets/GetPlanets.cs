using FastEndpoints;
using Web.Database;

namespace Web.Features.Planets;

public class GetPlanets
{
    public record Response(IEnumerable<Planet> Planets);

    public record Planet(
        int Id,
        string Name,
        decimal DistanceFromEarthInParsecs,
        int SunTemperatureInKelvin,
        decimal RelativeTemperatureToEarth,
        decimal RelativeSizeToEarth,
        decimal RelativeMassToEarth,
        decimal RelativeGravityToEarth,
        decimal YearInEarthDays,
        string SunColor,
        string PlanetProperty,
        int NumberOfStarsInSystem);

    public class Endpoint(DataContext dataContext) : EndpointWithoutRequest<Response>
    {
        public override void Configure()
        {
            Get("/planets");
            AllowAnonymous();
        }

        public override Task<Response> ExecuteAsync(CancellationToken ct)
        {
            var planets = dataContext.Planets
                .Select(p => new Planet(
                    p.Id,
                    p.Name,
                    p.DistanceFromEarthInParsecs,
                    p.SunTemperatureInKelvin,
                    p.RelativeTemperatureToEarth,
                    p.RelativeSizeToEarth,
                    p.RelativeMassToEarth,
                    p.RelativeGravityToEarth,
                    p.YearInEarthDays,
                    p.SunColor,
                    p.PlanetProperty,
                    p.NumberOfStarsInSystem
                    ))
                .ToList();

            return Task.FromResult(new Response(planets));
        }
    }
}