using Microsoft.EntityFrameworkCore;

namespace FutureMe.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Letter> Letters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

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