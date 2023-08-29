using Microsoft.EntityFrameworkCore;

namespace RommanyAPI.Store;

public class RommanyDBContext : DbContext
{
    public RommanyDBContext(DbContextOptions options) : base(options)
    {
    }
   public  DbSet<AboutUs> AboutUs{ get; set; }
   public  DbSet<Achievement> Achievements{ get; set; }
   public  DbSet<Product> Products{ get; set; }
   public DbSet<User> Users{ get; set; }
   public DbSet<UserLogin> UserLogin{ get; set; }

}
