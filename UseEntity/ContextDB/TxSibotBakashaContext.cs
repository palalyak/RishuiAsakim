using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Infrastructure.ModelsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class TxSibotBakashaContext : DbContext
    {
        public TxSibotBakashaContext()
        {
        }

        public virtual DbSet<RisTxSibotBakasha> RisTxSibotBakashas { get; set; }

        public TxSibotBakashaContext(DbContextOptions<TxSibotBakashaContext> options)
            : base(options)
        {
        }

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
            modelBuilder.Entity<RisTxSibotBakasha>(entity =>
            {
                entity.HasKey(e => e.PkCodeSibotBakasha)
                    .HasName("PK_ris_t_sibot_bakasha");

                entity.ToTable("ris_tx_sibot_bakasha");

                entity.HasIndex(e => e.KodSiba, "IX_ris_tx_sibot_bakasha_Kod_siba");

                entity.Property(e => e.PkCodeSibotBakasha).HasColumnName("PK_code_sibot_bakasha");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KodSiba).HasColumnName("Kod_siba");

                entity.Property(e => e.PkCodeBakasha).HasColumnName("PK_code_bakasha");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.HasSequence<int>("AdditionalPermitNumberSeq");

            modelBuilder.HasSequence<int>("CallNumberSeq");

            modelBuilder.HasSequence<int>("LicenseNumberSeq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
