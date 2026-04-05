
using Microsoft.EntityFrameworkCore;

namespace TandartsPraktijkAPI.Data
{
    public class APIDbContext : IdentityDbContext<Gebruiker>
    {
        public APIDbContext(DbContextOptions<APIDbContext>
            options) : base(options) { }

        public DbSet<Behandeling> Behandelingen { get; set; }
        public DbSet<Klant> Klanten { get; set; }

        public DbSet<Afspraak> Afspraken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Behandeling>().ToTable("Behandeling").Property(x=>x.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<Afspraak>().ToTable("Afspraak");

            modelBuilder.Entity<Afspraak>().HasOne(x=>x.Klant).WithMany(x=>x.Afspraken).HasForeignKey(x=>x.KlantId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Afspraak>().HasOne(x=>x.Behandeling).WithMany(x=>x.Afspraken).HasForeignKey(x=>x.BehandelingId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Afspraak>().HasOne(x=>x.Gebruiker).WithMany(x=>x.Afspraken).HasForeignKey(x=>x.GebruikerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
