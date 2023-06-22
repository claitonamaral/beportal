using BEPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace BEPortal
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Post> Post { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
    }
}
