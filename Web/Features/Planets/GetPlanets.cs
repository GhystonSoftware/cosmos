﻿using FastEndpoints;
using Web.Database;

namespace Web.Features.Planets;

public class GetPlanets
{
    public record Response(IEnumerable<Planet> Planets);
    
    public record Planet(
        int Id,
        string Name,
        decimal DistanceFromEarthInParsecs,
        decimal RelativeSunBrightness,
        int SunTemperatureInKelvin);

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
                    p.RelativeSunBrightness,
                    p.SunTemperatureInKelvin))
                .ToList();
            
            return Task.FromResult(new Response(planets));
        }
    }
}