using Microsoft.EntityFrameworkCore;

namespace Web.Database;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Planet> Planets { get; set; }
    
}