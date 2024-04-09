using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class SeruvToTotzaatSeruvContext : DbContext
    {
        public SeruvToTotzaatSeruvContext()
        {
        }

        public SeruvToTotzaatSeruvContext(DbContextOptions<SeruvToTotzaatSeruvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTxSeruvToTotzaatSeruv> RisTxSeruvToTotzaatSeruvs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if (DEBUG)
                optionsBuilder.UseSqlServer("Data Source=SQLDEV1902;Initial Catalog=db950_re;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;");


#else
                optionsBuilder.UseSqlServer("Data Source=SQLTST1902;Initial Catalog=db950_re;User Id=db950_t;Password=h#247950;TrustServerCertificate=True;");

#endif
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RisTxSeruvToTotzaatSeruv>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ris_tx_seruv_to_totzaat_seruv");

                entity.HasIndex(e => e.FkCodeSeruv, "IX_ris_tx_seruv_to_totzaat_seruv_fk_code_seruv");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.AimMeyuadLebitul).HasColumnName("aim_meyuad_lebitul");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkCodeSeruv).HasColumnName("fk_code_seruv");

                entity.Property(e => e.FkTotzaatSeruv).HasColumnName("fk_totzaat_seruv");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
