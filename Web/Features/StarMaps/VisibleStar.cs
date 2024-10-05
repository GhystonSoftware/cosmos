using Web.Features.Stars;

namespace Web.Features.StarMaps;

public class VisibleStar
{
    public int Id { get; set; }
    
    public int StarId { get; set; }
    public Star? Star { get; set; }
    
    public int StarMapId { get; set; }
    public StarMap? StarMap { get; set; }
    
    public decimal X { get; set; }
    public decimal Y { get; set; }
    public decimal Brightness { get; set; }
}