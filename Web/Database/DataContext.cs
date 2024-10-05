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
        modelBuilder.Entity<VisibleStar>()
            .HasMany(f => f.ConstellationLines)
            .WithMany(g => g.Stars)
            .UsingEntity<Dictionary<string, object>>(
                "ConstellationLineVisibleStar",
                j => j.HasOne<ConstellationLine>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<VisibleStar>().WithMany().OnDelete(DeleteBehavior.Cascade));
    }
    
    public DbSet<Star> Stars { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<StarMap> StarMaps { get; set; }
    public DbSet<VisibleStar> VisibleStars { get; set; }
    public DbSet<Constellation> Constellations { get; set; }
    public DbSet<ConstellationLine> ConstellationLines { get; set; }
}