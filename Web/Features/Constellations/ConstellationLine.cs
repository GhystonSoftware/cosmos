using Web.Features.StarMaps;

namespace Web.Features.Constellations;

public class ConstellationLine
{
    public ConstellationLine()
    {
    }

    public ConstellationLine(ICollection<VisibleStar>? stars)
    {
        Stars = stars;
    }

    public int Id { get; set; }
    public int ConstellationId { get; set; }
    
    public ICollection<VisibleStar>? Stars { get; set; }
}
