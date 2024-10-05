using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Web.Features.StarMaps;

namespace Web.Features.Stars;

public class Star
{
    public int Id { get; set; }
    [Column(TypeName = "VARCHAR(100)")] public string Name { get; set; } = "";
    
    [Precision(20, 4)] public decimal RightAscensionInDegrees { get; set; }
    [Precision(20, 4)] public decimal DeclinationInDegrees { get; set; }
    [Precision(20, 4)] public decimal DistanceFromEarthInParsecs { get; set; }
    
    public decimal Luminosity { get; set; }
    
    public ICollection<VisibleStar>? VisibleStars { get; set; }
}