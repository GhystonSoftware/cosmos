using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Web.Features.StarMaps;

namespace Web.Features.Planets;

public class Planet
{
    public int Id { get; set; }
    [Column(TypeName = "VARCHAR(100)")] public string Name { get; set; } = "";
    [Precision(20, 4)] public decimal RightAscensionInDegrees { get; set; }
    [Precision(20, 4)] public decimal DeclinationInDegrees { get; set; }
    [Precision(20, 4)] public decimal DistanceFromEarthInParsecs { get; set; }
    public ICollection<StarMap>? StarMaps { get; set; }

    public int SunTemperatureInKelvin { get; set; }
    [Precision(20, 4)] public decimal RelativeTemperatureToEarth { get; set; }
    [Precision(20, 4)] public decimal RelativeSizeToEarth { get; set; }
    [Precision(20, 4)] public decimal RelativeMassToEarth { get; set; }
    [Precision(20, 4)] public decimal RelativeGravityToEarth { get; set; }
    [Precision(20, 4)] public decimal YearInEarthDays { get; set; }
    [Column(TypeName = "VARCHAR(100)")] public string SunColor { get; set; } = "";
    [Column(TypeName = "VARCHAR(100)")] public string PlanetProperty { get; set; } = "";
    public int NumberOfStarsInSystem { get; set; }
}