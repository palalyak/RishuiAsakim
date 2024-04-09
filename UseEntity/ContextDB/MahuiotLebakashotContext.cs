using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class MahuiotLebakashotContext : DbContext
    {
        public MahuiotLebakashotContext()
        {
        }

        public MahuiotLebakashotContext(DbContextOptions<MahuiotLebakashotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTxMahuiotLebakasha> RisTxMahuiotLebakashas { get; set; }

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
            modelBuilder.Entity<RisTxMahuiotLebakasha>(entity =>
            {
                entity.HasKey(e => e.PkCodeParit)
                    .HasName("PK_ris_t_mahuiot_lebakasha");

                entity.ToTable("ris_tx_mahuiot_lebakasha");

                entity.HasIndex(e => e.KodParit, "IX_ris_tx_mahuiot_lebakasha_Kod_parit");

                entity.HasIndex(e => e.KodMaslul, "IX_ris_tx_mahuiot_lebakasha_kod_maslul");

                entity.HasIndex(e => e.StatusHamahutBebakasha, "IX_ris_tx_mahuiot_lebakasha_status_hamahut_bebakasha");

                entity.Property(e => e.PkCodeParit).HasColumnName("PK_code_parit");

                entity.Property(e => e.CodeShelavNuchachi).HasColumnName("Code_shelav_nuchachi");

                entity.Property(e => e.HosfatMautButzaBaesek).HasColumnName("Hosfat_maut_butza_baesek");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.KodMaslul).HasColumnName("kod_maslul");

                entity.Property(e => e.KodParit).HasColumnName("Kod_parit");

                entity.Property(e => e.KvutzatShimushChoreg).HasColumnName("kvutzat_shimush_choreg");

                entity.Property(e => e.MahutRashit).HasColumnName("mahut_rashit");

                entity.Property(e => e.Mevotal).HasColumnName("mevotal");

                entity.Property(e => e.Mokpe).HasColumnName("mokpe");

                entity.Property(e => e.NidrashTuchnitHadasha).HasColumnName("Nidrash_tuchnit_hadasha");

                entity.Property(e => e.PkCodeEssek).HasColumnName("PK_code_essek");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ShimushChoregLeheiter).HasColumnName("shimush_choreg_leheiter");

                entity.Property(e => e.ShimushChoregLetaba).HasColumnName("shimush_choreg_letaba");

                entity.Property(e => e.StatusHamahutBebakasha).HasColumnName("status_hamahut_bebakasha");

                entity.Property(e => e.SugHakpa).HasColumnName("Sug_hakpa");

                entity.Property(e => e.TaarichPkiatShimushChoreg).HasColumnName("taarich_pkiat_shimush_choreg");

                entity.Property(e => e.TaarichStatus).HasColumnName("taarich_status");

                entity.Property(e => e.TarichBitul).HasColumnName("Tarich_bitul");

                entity.Property(e => e.TarichMokpe).HasColumnName("tarich_mokpe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
