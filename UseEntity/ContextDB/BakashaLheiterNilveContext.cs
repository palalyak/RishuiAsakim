using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class BakashaLheiterNilveContext : DbContext
    {
        public BakashaLheiterNilveContext()
        {
        }

        public BakashaLheiterNilveContext(DbContextOptions<BakashaLheiterNilveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTBakashaLheiterNilve> RisTBakashaLheiterNilves { get; set; }

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
            modelBuilder.Entity<RisTBakashaLheiterNilve>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ris_t_bakasha_lheiter_nilve");

                entity.HasIndex(e => e.FkCodeMahuiotLebakasha, "IX_ris_t_bakasha_lheiter_nilve_fk_code_mahuiot_lebakasha");

                entity.HasIndex(e => e.FkSugHeiterNilve, "IX_ris_t_bakasha_lheiter_nilve_fk_sug_heiter_nilve");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Adifut).HasColumnName("adifut");

                entity.Property(e => e.CodeMishtameshMevatel).HasColumnName("code_mishtamesh_mevatel");

                entity.Property(e => e.CodeMisparBakasha).HasColumnName("code_mispar_bakasha");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DargaLechishuvHaagra).HasColumnName("darga_lechishuv_haagra");

                entity.Property(e => e.FkCodeEssek).HasColumnName("fk_code_essek");

                entity.Property(e => e.FkCodeMahuiotLebakasha).HasColumnName("fk_code_mahuiot_lebakasha");

                entity.Property(e => e.FkStatusBakasha).HasColumnName("fk_status_bakasha");

                entity.Property(e => e.FkSugHeiterNilve).HasColumnName("fk_sug_heiter_nilve");

                entity.Property(e => e.HimAlChofYam).HasColumnName("him_al_chof_yam");

                entity.Property(e => e.IndikatziaLemidrachaShetachPatuach).HasColumnName("indikatzia_lemidracha_shetach_patuach");

                entity.Property(e => e.IndikatziaToShetachDetailMivne).HasColumnName("indikatzia_to_shetach_detail_mivne");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KamutKisaot).HasColumnName("kamut_kisaot");

                entity.Property(e => e.KamutShulchanot).HasColumnName("kamut_shulchanot");

                entity.Property(e => e.KamutShulchanotBar).HasColumnName("kamut_shulchanot_bar");

                entity.Property(e => e.KodEzor).HasColumnName("kod_ezor");

                entity.Property(e => e.MerchakMehamidrachaDrisha)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("merchak_mehamidracha_drisha");

                entity.Property(e => e.MerchakMehamidrachaKviaa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("merchak_mehamidracha_kviaa");

                entity.Property(e => e.Mevutal).HasColumnName("mevutal");

                entity.Property(e => e.Michsholim).HasColumnName("michsholim");

                entity.Property(e => e.MisparHagashaHeiterNilve).HasColumnName("mispar_hagasha_heiter_nilve");

                entity.Property(e => e.MispurMehagrala).HasColumnName("mispur_mehagrala");

                entity.Property(e => e.ShaaHagrala).HasColumnName("shaa_hagrala");

                entity.Property(e => e.ShaaMaxDrisha).HasColumnName("shaa_max_drisha");

                entity.Property(e => e.ShaaMaxKviaa).HasColumnName("shaa_max_kviaa");

                entity.Property(e => e.ShaaMinDrisha).HasColumnName("shaa_min_drisha");

                entity.Property(e => e.ShaaMinKviaa).HasColumnName("shaa_min_kviaa");

                entity.Property(e => e.ShetachHaheiterDrisha)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_haheiter_drisha");

                entity.Property(e => e.ShetachHaheiterKviaa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_haheiter_kviaa");

                entity.Property(e => e.SibatBitol).HasColumnName("sibat_bitol");

                entity.Property(e => e.SwEsekChotzeTzirMerkazi).HasColumnName("sw_esek_chotze_tzir_merkazi");

                entity.Property(e => e.SwEsekMerkazKolel5).HasColumnName("sw_esek_merkaz_kolel_5");

                entity.Property(e => e.SwEsekRechovMischari).HasColumnName("sw_esek_rechov_mischari");

                entity.Property(e => e.SwEsekTzirMerkazi).HasColumnName("sw_esek_tzir_merkazi");

                entity.Property(e => e.SwHaskamaLetoranut).HasColumnName("sw_haskama_letoranut");

                entity.Property(e => e.SwMarkolGadolKatan).HasColumnName("sw_markol_gadol_katan");

                entity.Property(e => e.TaarichBitol).HasColumnName("taarich_bitol");

                entity.Property(e => e.TaarichHagrala).HasColumnName("taarich_hagrala");

                entity.Property(e => e.TaarichMaxDrisha).HasColumnName("taarich_max_drisha");

                entity.Property(e => e.TaarichMaxKviaa).HasColumnName("taarich_max_kviaa");

                entity.Property(e => e.TaarichMinDrisha).HasColumnName("taarich_min_drisha");

                entity.Property(e => e.TaarichMinKviaa).HasColumnName("taarich_min_kviaa");

                entity.Property(e => e.TarichHagashatBakashaHeiterNilve).HasColumnName("tarich_hagashat_bakasha_heiter_nilve");

                entity.Property(e => e.TarichStatusBakasha).HasColumnName("tarich_status_bakasha");

                entity.Property(e => e.YomSgira).HasColumnName("yom_sgira");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
