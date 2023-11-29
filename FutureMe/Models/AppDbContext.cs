using Microsoft.EntityFrameworkCore;

namespace FutureMe.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Letter> letters { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Comment> comments { get; set; }
    }
}
