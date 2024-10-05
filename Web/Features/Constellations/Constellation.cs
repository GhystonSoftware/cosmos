using System.ComponentModel.DataAnnotations.Schema;
using Web.Features.StarMaps;

namespace Web.Features.Constellations;

public class Constellation
{
    public int Id { get; set; }
    [Column(TypeName = "VARCHAR(100)")] public string Name { get; set; } = "";
    
    public int StarMapId { get; set; }
    public StarMap? StarMap { get; set; }
    
    public string CreatedBy { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    
    public ICollection<ConstellationLine>? Lines { get; set; }
}