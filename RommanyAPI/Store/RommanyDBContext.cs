using Microsoft.EntityFrameworkCore;

namespace RommanyAPI.Store;

public class RommanyDBContext : DbContext
{
    public RommanyDBContext(DbContextOptions options) : base(options)
    {
    }
    DbSet<AboutUs> AboutUs{ get; set; }
    DbSet<Achievement> Achievements{ get; set; }
    DbSet<Product> Products{ get; set; }
}
