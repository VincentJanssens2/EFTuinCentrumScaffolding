using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model
{
    public partial class EFTuincentrumContext : DbContext
    {
        public EFTuincentrumContext()
        {
        }

        public EFTuincentrumContext(DbContextOptions<EFTuincentrumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Leveranciers> Leveranciers { get; set; }
        public virtual DbSet<Planten> Planten { get; set; }
        public virtual DbSet<Soorten> Soorten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=EFTuincentrum;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leveranciers>(entity =>
            {
                entity.HasKey(e => e.LevId)
                    .HasName("Leveranciers$PrimaryKey");

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PostNr)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Woonplaats)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Planten>(entity =>
            {
                entity.HasKey(e => e.PlantId)
                    .HasName("Planten$PrimaryKey");

                entity.Property(e => e.Kleur)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.VerkoopPrijs).HasColumnType("money");

                entity.HasOne(d => d.Lev)
                    .WithMany(p => p.Planten)
                    .HasForeignKey(d => d.LevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Planten$LeveranciersPlanten");

                entity.HasOne(d => d.Soort)
                    .WithMany(p => p.Planten)
                    .HasForeignKey(d => d.SoortId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Planten$SoortenPlanten");
            });

            modelBuilder.Entity<Soorten>(entity =>
            {
                entity.HasKey(e => e.SoortId)
                    .HasName("Soorten$PrimaryKey");

                entity.Property(e => e.Soort)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
