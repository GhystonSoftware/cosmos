using Microsoft.EntityFrameworkCore;

public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; }
    [Precision(20, 4)] public decimal RightAscensionInDegrees { get; set; }
    [Precision(20, 4)] public decimal DeclinationInDegrees { get; set; }
    [Precision(20, 4)] public decimal DistanceFromEarthInParsecs { get; set; }
}