using Eventures.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Data
{
    public class EventuresDbContext : IdentityDbContext<EventuresUser, IdentityRole, string>
    {
        public DbSet<EventuresUser> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public EventuresDbContext(DbContextOptions options) : base(options)
        {
        }

        protected EventuresDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventuresUser>()
                .HasKey(u => u.UniqueCitizenNumber);

            builder.Entity<Event>()
                .HasKey(e => e.Id);

            base.OnModelCreating(builder);
        }
    }
}
