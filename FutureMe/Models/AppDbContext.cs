using FutureMe.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FutureMe.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Letter> Letters { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for letters
            modelBuilder.Entity<Letter>().HasData(
                new Letter
                {
                    Id = 1,
                    Content = "Dear future me, I hope you are doing well and have achieved your goals. I am writing this letter to remind you of the things that matter to you and to encourage you to keep going. Remember to be grateful for what you have, to be kind to yourself and others, and to enjoy the present moment. You have come a long way and I am proud of you. Love, your past self.",
                    WritingDate = DateTime.Parse("2023-12-09T12:01:23+01:00").ToUniversalTime(),
                    SendingDate = DateTime.Parse("2024-12-09T12:01:23+01:00").ToUniversalTime(),
                    IsPublic = true,
                    Email = "user1@example.com",
                    Title = "A letter to myself",
                    IsSent = false,
                    UserId = null
                },
                new Letter
                {
                    Id = 2,
                    Content = "Hello future me, I am writing this letter to tell you that you are awesome and that you can do anything you set your mind to. I know you have faced many challenges and overcome many obstacles, but you never gave up. You are strong, resilient, and courageous. I want you to remember that you are not alone, that you have people who love you and support you. I also want you to have fun and enjoy life, because you deserve it. You are amazing and I love you. Sincerely, your past self.",
                    WritingDate = DateTime.Parse("2023-12-09T12:01:23+01:00").ToUniversalTime(),
                    SendingDate = DateTime.Parse("2025-12-09T12:01:23+01:00").ToUniversalTime(),
                    IsPublic = false,
                    Email = "user2@example.com",
                    Title = "A letter to myself",
                    IsSent = false,
                    UserId = null
                }
            );
        }
    }
}
