using Microsoft.EntityFrameworkCore;

namespace HydroBookApi.Models
{
    public class HydroBookContext : DbContext
    {
        public HydroBookContext(DbContextOptions<HydroBookContext> options)
            : base(options)
        {
        }

        public DbSet<Story> HydroBookStories { get; set; }

    }
}