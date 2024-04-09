using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class ShovarTashlumRishayonContext : DbContext
    {
        public ShovarTashlumRishayonContext()
        {
        }

        public ShovarTashlumRishayonContext(DbContextOptions<ShovarTashlumRishayonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTShovarTashlumRishayon> RisTShovarTashlumRishayons { get; set; }

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
            modelBuilder.Entity<RisTShovarTashlumRishayon>(entity =>
            {
                entity.HasKey(e => e.PkCodeShovarTashlumRishayon);

                entity.ToTable("ris_t_shovar_tashlum_rishayon");

                entity.HasIndex(e => e.FkCodeBakasha, "IX_ris_t_shovar_tashlum_rishayon_fk_code_bakasha");

                entity.Property(e => e.PkCodeShovarTashlumRishayon).HasColumnName("PK_code_shovar_tashlum_rishayon");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkCodeBakasha).HasColumnName("fk_code_bakasha");

                entity.Property(e => e.FkCodeBakashaLeiterNilve).HasColumnName("fk_code_bakasha_leiter_nilve");

                entity.Property(e => e.FkCodeEssek).HasColumnName("fk_code_essek");

                entity.Property(e => e.FkCodeRishayonEssek).HasColumnName("fk_code_rishayon_essek");

                entity.Property(e => e.FkMisparHagasha).HasColumnName("Fk_mispar_hagasha");

                entity.Property(e => e.FkStatusTashlum).HasColumnName("Fk_status_tashlum");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MisparMidaMukdam).HasColumnName("Mispar_mida_mukdam");

                entity.Property(e => e.MisparShuvar).HasColumnName("Mispar_shuvar");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SchumHaagra)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("schum_haagra");

                entity.Property(e => e.SugShovar).HasColumnName("sug_shovar");

                entity.Property(e => e.TaarichAcharonLetashlum).HasColumnName("taarich_acharon_letashlum");

                entity.Property(e => e.TaarishTashlum).HasColumnName("Taarish_tashlum");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
