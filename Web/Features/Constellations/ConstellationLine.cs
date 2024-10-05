using Web.Features.StarMaps;

namespace Web.Features.Constellations;

public class ConstellationLine
{
    public int Id { get; set; }
    public int ConstellationId { get; set; }
    
    public int Star1Id { get; set; }
    public VisibleStar? Star1 { get; set; }
    
    public int Star2Id { get; set; }
    public VisibleStar? Star2 { get; set; }
}