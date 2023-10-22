using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APCore.Models
{
    public partial class ppa_vareshContext : DbContext
    {
        public ppa_vareshContext()
        {
        }

        public ppa_vareshContext(DbContextOptions<ppa_vareshContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OFPImport> OFPImports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:EPDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AI");

            modelBuilder.Entity<OFPImport>(entity =>
            {
                entity.ToTable("OFPImport");

                entity.Property(e => e.DOW).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DateConfirmed).HasColumnType("datetime");

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.DateFlight).HasColumnType("date");

                entity.Property(e => e.DateUpdate)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Destination)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FLL).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FPFuel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FPTripFuel).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FileName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JAPlan1).IsUnicode(false);

                entity.Property(e => e.JAPlan2).IsUnicode(false);

                entity.Property(e => e.JCSTBL).IsUnicode(false);

                entity.Property(e => e.JFuel).IsUnicode(false);

                entity.Property(e => e.JLDatePICApproved).HasColumnType("datetime");

                entity.Property(e => e.JLSignedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JPlan).IsUnicode(false);

                entity.Property(e => e.JWTDRF).IsUnicode(false);

                entity.Property(e => e.MCI).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Origin)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PIC)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);

                entity.Property(e => e.TextOutput).IsUnicode(false);

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserConfirmed)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
