using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Password> Passwords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration pour l'entité Application
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Type).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();

                // Relation one-to-many avec Password
                entity.HasMany(a => a.Passwords)
                      .WithOne(p => p.Application)
                      .HasForeignKey(p => p.ApplicationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuration pour l'entité Password
            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
                entity.Property(e => e.EncryptedPassword).IsRequired();
                entity.Property(e => e.Notes).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).IsRequired();

                // Relation many-to-one avec Application
                entity.HasOne(p => p.Application)
                      .WithMany(a => a.Passwords)
                      .HasForeignKey(p => p.ApplicationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}