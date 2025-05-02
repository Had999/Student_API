using School_API.Models.Domain;

namespace School_API.Data
{
    public class School_DbContext : DbContext
    {
        public School_DbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Students> Students { get; set; }
    }
}
