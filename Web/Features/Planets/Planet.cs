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

    [Precision(20, 4)] public decimal RelativeSunBrightness { get; set; }
    public int SunTemperatureInKelvin { get; set; }
    
    // TODO: add the other informational fields:
    // - [ ] Relative radius compared to earth
    // - [ ] Relative mass compared to earth
    // - [ ] Relative gravity compared to earth? (we need to calculate this either at runtime or before inserting the data)
    // - [ ] Length of year
    // - [ ] Number of suns in the sky
}