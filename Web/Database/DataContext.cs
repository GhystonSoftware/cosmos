using Microsoft.EntityFrameworkCore;
using Web.Features.Constellations;
using Web.Features.Planets;
using Web.Features.StarMaps;
using Web.Features.Stars;

namespace Web.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    
    public DbSet<Star> Stars { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<StarMap> StarMaps { get; set; }
    public DbSet<VisibleStar> VisibleStars { get; set; }
    public DbSet<Constellation> Constellations { get; set; }
    public DbSet<ConstellationLine> ConstellationLines { get; set; }
}