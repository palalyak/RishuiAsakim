using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class KtovetEssekContext : DbContext
    {
        public KtovetEssekContext()
        {
        }

        public KtovetEssekContext(DbContextOptions<KtovetEssekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTKtovetEssek> RisTKtovetEsseks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if (DEBUG)
                optionsBuilder.UseSqlServer("Data Source=SQLDEV1902;Initial Catalog=db950_ne;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;");


#else
                optionsBuilder.UseSqlServer("Data Source=SQLTST1902;Initial Catalog=db950_ne;User Id=db950_t;Password=h#247950;TrustServerCertificate=True;");

#endif
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RisTKtovetEssek>(entity =>
            {
                entity.HasKey(e => e.PkCodeKtovetEssek);

                entity.ToTable("ris_t_ktovet_essek");

                entity.HasIndex(e => e.KodMerkazMischari, "IX_ris_t_ktovet_essek_kod_merkaz_mischari");

                entity.Property(e => e.PkCodeKtovetEssek).HasColumnName("pk_code_ktovet_essek");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dira).HasColumnName("dira");

                entity.Property(e => e.Gush)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("gush");

                entity.Property(e => e.Helka)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("helka");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Knisa).HasColumnName("knisa");

                entity.Property(e => e.KodBait).HasColumnName("kod_bait");

                entity.Property(e => e.KodKoma).HasColumnName("kod_koma");

                entity.Property(e => e.KodMerkazMischari).HasColumnName("kod_merkaz_mischari");

                entity.Property(e => e.Mikud).HasColumnName("mikud");

                entity.Property(e => e.MisparChanut).HasColumnName("mispar_chanut");

                entity.Property(e => e.MisparShchuna).HasColumnName("Mispar_shchuna");

                entity.Property(e => e.PkCodeEssek).HasColumnName("pk_code_essek");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SemelRechov).HasColumnName("semel_rechov");

                entity.Property(e => e.SugKtovet).HasColumnName("sug_ktovet");

                entity.Property(e => e.TaDoar)
                    .HasMaxLength(5)
                    .HasColumnName("ta_doar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
