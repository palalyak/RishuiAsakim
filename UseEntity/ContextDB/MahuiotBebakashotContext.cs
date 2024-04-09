using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class MahuiotBebakashotContext : DbContext
    {
        public MahuiotBebakashotContext()
        {
        }

        public MahuiotBebakashotContext(DbContextOptions<MahuiotBebakashotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTxMahuiotBebakashot> RisTxMahuiotBebakashots { get; set; }

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
            modelBuilder.Entity<RisTxMahuiotBebakashot>(entity =>
            {
                entity.HasKey(e => e.PkKesherMaut)
                    .HasName("PK_ris_t_kesher_mahuiot_lebakashot");

                entity.ToTable("ris_tx_mahuiot_bebakashot");

                entity.HasIndex(e => e.FkCodeParit, "IX_ris_tx_mahuiot_bebakashot_FK_code_parit");

                entity.Property(e => e.PkKesherMaut).HasColumnName("Pk_kesher_maut");

                entity.Property(e => e.AimMvutal).HasColumnName("aim_mvutal");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkBakasha).HasColumnName("Fk_bakasha");

                entity.Property(e => e.FkCodeParit).HasColumnName("FK_code_parit");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
