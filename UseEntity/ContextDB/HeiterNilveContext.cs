using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class HeiterNilveContext : DbContext
    {
        public HeiterNilveContext()
        {
        }

        public HeiterNilveContext(DbContextOptions<HeiterNilveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTHeiterNilve> RisTHeiterNilves { get; set; }

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
            modelBuilder.Entity<RisTHeiterNilve>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ris_t_heiter_nilve");

                entity.HasIndex(e => e.FkBakashaLheiterNilve, "IX_ris_t_heiter_nilve_fk_bakasha_lheiter_nilve");

                entity.HasIndex(e => e.FkStatusHeiterNilve, "IX_ris_t_heiter_nilve_fk_status_heiter_nilve");

                entity.HasIndex(e => e.FkSugHeiterNilve, "IX_ris_t_heiter_nilve_fk_sug_heiter_nilve");

                entity.HasIndex(e => e.SibatBitol, "IX_ris_t_heiter_nilve_sibat_bitol");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeMishtameshMevatel).HasColumnName("code_mishtamesh_mevatel");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Esber).HasColumnName("esber");

                entity.Property(e => e.FkBakashaLheiterNilve).HasColumnName("fk_bakasha_lheiter_nilve");

                entity.Property(e => e.FkCodeEssek).HasColumnName("fk_code_essek");

                entity.Property(e => e.FkStatusHeiterNilve).HasColumnName("fk_status_heiter_nilve");

                entity.Property(e => e.FkSugHeiterNilve).HasColumnName("fk_sug_heiter_nilve");

                entity.Property(e => e.IndikatziaLemidrachaShetachPatuach).HasColumnName("indikatzia_lemidracha_shetach_patuach");

                entity.Property(e => e.IndikatziaToShetachDetailMivne).HasColumnName("indikatzia_to_shetach_detail_mivne");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MerchakMehamidracha)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("merchak_mehamidracha");

                entity.Property(e => e.Mevutal).HasColumnName("mevutal");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SibatBitol).HasColumnName("sibat_bitol");

                entity.Property(e => e.TaarichBitol).HasColumnName("taarich_bitol");

                entity.Property(e => e.TaarichMax).HasColumnName("taarich_max");

                entity.Property(e => e.TaarichMin).HasColumnName("taarich_min");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
