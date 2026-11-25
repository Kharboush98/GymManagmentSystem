using GymManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymManagmentSystem.Contexts
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
