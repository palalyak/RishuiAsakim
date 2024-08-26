using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class EssecContext : DbContext
    {
        public EssecContext()
        {
        }

        public EssecContext(DbContextOptions<EssecContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTEssek> RisTEsseks { get; set; }

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
            modelBuilder.Entity<RisTEssek>(entity =>
            {
                entity.HasKey(e => e.PkCodeEssek);

                entity.ToTable("ris_t_essek");

                entity.HasIndex(e => e.MisRishuiEsek, "IX_ris_t_essek_Mis_rishui_esek")
                    .IsUnique();

                

                entity.Property(e => e.PkCodeEssek).HasColumnName("PK_code__essek");

                entity.Property(e => e.AimMesukan).HasColumnName("aim_mesukan");

                entity.Property(e => e.AimShimur).HasColumnName("aim_shimur");

                entity.Property(e => e.CodeMahutIkarit).HasColumnName("code_mahut_ikarit");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DoarElectroni).HasColumnName("doar_electroni");

                entity.Property(e => e.EssekBesikun).HasColumnName("essek_besikun");

                entity.Property(e => e.Gova)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("gova");

                entity.Property(e => e.HaaimKayemetTuchnitMeusheret).HasColumnName("Haaim_kayemet_tuchnit_meusheret");

                entity.Property(e => e.HearaMarkol).HasColumnName("heara_markol");

                entity.Property(e => e.Hearot).HasColumnName("hearot");

                entity.Property(e => e.HozeOArnuna).HasColumnName("Hoze_o_arnuna");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                

                entity.Property(e => e.LoTaonRishoi).HasColumnName("lo_taon_rishoi");

                entity.Property(e => e.MezaheKtovetBinyan).HasColumnName("mezahe_ktovet_binyan");

                entity.Property(e => e.MikumKlaliChatzerMivne).HasColumnName("mikum_klali_chatzer_mivne");

                entity.Property(e => e.MisRishuiEsek)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("Mis_rishui_esek");

                entity.Property(e => e.MishtameshMakpie).HasColumnName("mishtamesh_makpie");

                entity.Property(e => e.MisparAnashim).HasColumnName("mispar_anashim");

                entity.Property(e => e.MisparBakashaAchrona).HasColumnName("mispar_bakasha_achrona");

                entity.Property(e => e.MisparChadarim).HasColumnName("mispar_chadarim");

                entity.Property(e => e.MisparHeshbonArnona).HasColumnName("mispar_heshbon_arnona");

                entity.Property(e => e.MisparKibuyEsh).HasColumnName("mispar_kibuy_esh");

                entity.Property(e => e.MisparMekomotChanaya).HasColumnName("mispar_mekomot_chanaya");

                entity.Property(e => e.MisparMekomotChanayaNechim).HasColumnName("mispar_mekomot_chanaya_nechim");

                entity.Property(e => e.MisparMekomotYeshiva).HasColumnName("mispar_mekomot_yeshiva");

                entity.Property(e => e.MisparOvdim).HasColumnName("mispar_ovdim");

                entity.Property(e => e.MisparTelephon)
                    .HasMaxLength(10)
                    .HasColumnName("mispar_telephon");

                entity.Property(e => e.MisparTelephon2)
                    .HasMaxLength(10)
                    .HasColumnName("mispar_telephon2");

                entity.Property(e => e.MisparTzavSgira).HasColumnName("Mispar_tzav_sgira");

                entity.Property(e => e.MsCheshbonChoze)
                    .HasMaxLength(13)
                    .HasColumnName("ms_cheshbon_choze");

                entity.Property(e => e.Mukpaa).HasColumnName("mukpaa");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ShemEssek).HasColumnName("Shem_essek");

                entity.Property(e => e.ShetachHaessekBaarnona)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_haessek_baarnona");

                entity.Property(e => e.ShetachHaessekHamadud)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_haessek_hamadud");

                entity.Property(e => e.ShetachHaessekHameduvach)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_haessek_hameduvach");

                entity.Property(e => e.ShetachMechira)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_mechira");

                entity.Property(e => e.ShetachPargod)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_pargod");

                entity.Property(e => e.ShetachShulhanot)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_shulhanot");

                entity.Property(e => e.SugGishaLesek).HasColumnName("sug_gisha_lesek");

                entity.Property(e => e.SugHakpaa).HasColumnName("sug_hakpaa");

                entity.Property(e => e.SugMivne).HasColumnName("sug_mivne");

                entity.Property(e => e.TaarichHakpaa).HasColumnName("taarich_hakpaa");

                entity.Property(e => e.TaarichPtichatEssekKabalatEssek).HasColumnName("taarich_ptichat_essek_kabalat_essek");

                entity.Property(e => e.TeudatZehutEsek)
                    .HasMaxLength(15)
                    .HasColumnName("Teudat_zehut_esek");

                entity.Property(e => e.TeurEsek).HasColumnName("Teur_esek");

                entity.Property(e => e.TeurMikumHaessek).HasColumnName("teur_mikum_haessek");

                entity.Property(e => e.TikMahsanKashor).HasColumnName("tik_mahsan_kashor");

                entity.Property(e => e.TikMishtaraAlfa).HasColumnName("tik_mishtara_alfa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
