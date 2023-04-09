using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskScheduler.Core.Entities;

namespace TaskScheduler.Infrastructure.Data.Repositories
{
    public class EfContext : IdentityDbContext<ApplicationUser>
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
