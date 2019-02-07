


using Microsoft.EntityFrameworkCore;

namespace Ensurance.Models
{
    public class EnsuranceContext : DbContext
    {
        public EnsuranceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PolicyCovering>()
                .HasKey(bc => new { bc.PolicyNumber, bc.CoveringID });
            modelBuilder.Entity<PolicyCovering>()
                .HasOne(bc => bc.Policy)
                .WithMany(b => b.CoveringPolicy)
                .HasForeignKey(bc => bc.PolicyNumber);
            modelBuilder.Entity<PolicyCovering>()
                .HasOne(bc => bc.Cover)
                .WithMany(c => c.CoveringPolicy)
                .HasForeignKey(bc => bc.CoveringID);

            // Coverings
            modelBuilder.Entity<Covering>().HasData(new Covering
            {
                ID = 1,
                Description = "Terremoto"
            }, new Covering
            {
                ID = 2,
                Description = "Incendio"
            }, new Covering
            {
                ID = 3,
                Description = "Robo"
            });

            // Clients
            modelBuilder.Entity<Client>().HasData(new Client
            {
                Identification = 123,
                Name = "Diego Jimenez"
            }, new Client
            {
                Identification = 21213,
                Name = "Juan Manuel"
            }, new Client
            {
                Identification = 3324324,
                Name = "Leidy Jhoana"
            });
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Covering> Coverings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPolicy> ClientPolicies { get; set; }
        public DbSet<PolicyCovering> PolicyCoverings { get; set; }

    }
}
