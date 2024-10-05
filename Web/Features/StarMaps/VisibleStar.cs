using Microsoft.EntityFrameworkCore;
using Web.Features.Stars;

namespace Web.Features.StarMaps;

public class VisibleStar
{
    public int Id { get; set; }
    
    public int StarId { get; set; }
    public Star? Star { get; set; }
    
    public int StarMapId { get; set; }
    public StarMap? StarMap { get; set; }
    
    [Precision(5, 2)] public decimal X { get; set; }
    [Precision(5, 2)] public decimal Y { get; set; }
    [Precision(3, 3)] public decimal Brightness { get; set; }
}