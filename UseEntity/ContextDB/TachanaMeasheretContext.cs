using System;
using System.Collections.Generic;
using System.Configuration;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class TachanaMeasheretContext : DbContext
    {
        public TachanaMeasheretContext()
        {
        }

        public TachanaMeasheretContext(DbContextOptions<TachanaMeasheretContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTTachanaMeasheret> RisTTachanaMeasherets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConfigurationManager.ConnectionStrings["ConStr"];
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
            modelBuilder.Entity<RisTTachanaMeasheret>(entity =>
            {
                entity.HasKey(e => e.PkCodeTachana);

                entity.ToTable("ris_t_tachana_measheret");

                entity.HasIndex(e => e.PathAlertStandartId, "IX_ris_t_tachana_measheret_PathAlertStandartId");

                entity.HasIndex(e => e.FkBakashaLheiterNilve, "IX_ris_t_tachana_measheret_fk_bakasha_lheiter_nilve");

                entity.HasIndex(e => e.FkCodeDochBikorBesek, "IX_ris_t_tachana_measheret_fk_code_doch_bikor_besek");

                entity.HasIndex(e => e.FkCodeMahuiotLebakashaDochBikor, "IX_ris_t_tachana_measheret_fk_code_mahuiot_lebakasha_doch_bikor");

                entity.HasIndex(e => e.FkCodeSibatEaTerufMismach, "IX_ris_t_tachana_measheret_fk_code_sibat_ea_teruf_mismach");

                entity.HasIndex(e => e.StatusAcharon, "IX_ris_t_tachana_measheret_status_acharon");

                entity.HasIndex(e => e.SugTachana, "IX_ris_t_tachana_measheret_sug_tachana");

                entity.Property(e => e.PkCodeTachana).HasColumnName("PK_code_tachana");

                entity.Property(e => e.AarachaMishtara).HasColumnName("aaracha_mishtara");

                entity.Property(e => e.BetipulEsek).HasColumnName("betipul_esek");

                entity.Property(e => e.BetipulTachana).HasColumnName("betipul_tachana");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkBakashaLheiterNilve).HasColumnName("fk_bakasha_lheiter_nilve");

                entity.Property(e => e.FkCodeDochBikorBesek).HasColumnName("fk_code_doch_bikor_besek");

                entity.Property(e => e.FkCodeMahuiotLebakashaDochBikor).HasColumnName("fk_code_mahuiot_lebakasha_doch_bikor");

                entity.Property(e => e.FkCodeSibatEaTerufMismach).HasColumnName("fk_code_sibat_ea_teruf_mismach");

                entity.Property(e => e.FkKodHavatDaat).HasColumnName("Fk_kod_havat_daat");

                entity.Property(e => e.GoremMetapel).HasColumnName("gorem_metapel");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KamutYamimLsyumTipul).HasColumnName("kamut_yamim_lsyum_tipul");

                entity.Property(e => e.KamutYamimletipulBealim).HasColumnName("kamut_yamimletipul_bealim");

                entity.Property(e => e.MeadkenHeiterZmaniAchron).HasColumnName("meadken_heiter_zmani_achron");

                entity.Property(e => e.MishtameshMadkenStatus).HasColumnName("mishtamesh_madken_status");

                entity.Property(e => e.MishtameshMeadkenTaarichAcharonHaavaraLetipulBealim).HasColumnName("mishtamesh_meadken_taarich_acharon_haavara_letipul_bealim");

                entity.Property(e => e.MishtameshMeadkenTaarichAcharonSiumTipulBealim).HasColumnName("mishtamesh_meadken_taarich_acharon_sium_tipul_bealim");

                entity.Property(e => e.PkCodeEssek).HasColumnName("PK_code_essek");

                entity.Property(e => e.PkCodeMautBebakasha).HasColumnName("PK_code_maut_bebakasha");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ShemNatzig).HasColumnName("Shem_natzig");

                entity.Property(e => e.StatusAcharon).HasColumnName("status_acharon");

                entity.Property(e => e.SugTachana).HasColumnName("sug_tachana");

                entity.Property(e => e.TaarichAcharonHaavaraLetipulBealim).HasColumnName("taarich_acharon_haavara_letipul_bealim");

                entity.Property(e => e.TaarichAcharonSiumTipulBealim).HasColumnName("taarich_acharon_sium_tipul_bealim");

                entity.Property(e => e.TaarichIdkunAcharon).HasColumnName("taarich_idkun_acharon");

                entity.Property(e => e.TaarichLehiterZmaniAcharon).HasColumnName("taarich_lehiter_zmani_acharon");

                entity.Property(e => e.TaarichSiumTipul).HasColumnName("taarich_sium_tipul");

                entity.Property(e => e.TaarichTokefHiterZmaniAcharon).HasColumnName("taarich_tokef_hiter_zmani_acharon");

                entity.Property(e => e.TaarichTukef).HasColumnName("Taarich_tukef");

                entity.Property(e => e.TarichStatusAcharon).HasColumnName("tarich_status_acharon");

                entity.Property(e => e.TeurHavatDaat).HasColumnName("Teur_havat_daat");

                entity.Property(e => e.YamimLeiter).HasColumnName("yamim_leiter");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
