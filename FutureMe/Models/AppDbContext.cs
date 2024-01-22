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

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            string letterJSon = System.IO.File.ReadAllText("Letters.Json");
            List<Letter>? letters = System.Text.Json.
            JsonSerializer.Deserialize<List<Letter>>(letterJSon);
            //Seed to categorie
            foreach (Letter l in letters)
                model.Entity<Letter>()
                .HasData(l);
        }
    }
}