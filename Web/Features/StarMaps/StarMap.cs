using Web.Features.Planets;

namespace Web.Features.StarMaps;

public class StarMap
{
    public int Id { get; set; }
    public int PlanetId { get; set; }
    public Planet? Planet { get; set; }
    public ICollection<VisibleStar>? VisibleStars { get; set; }
}