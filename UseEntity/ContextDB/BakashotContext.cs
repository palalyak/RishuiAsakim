using System;
using System.Collections.Generic;
using Infrastructure.ModelsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class BakashotContext : DbContext
    {
        public BakashotContext()
        {
        }

        public BakashotContext(DbContextOptions<BakashotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTBakasha> RisTBakashas { get; set; }

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
            modelBuilder.Entity<RisTBakasha>(entity =>
            {
                entity.HasKey(e => e.PkCodeBakasha);

                entity.ToTable("ris_t_bakasha");

                entity.HasIndex(e => e.FkKodStatusBakashaLehasava, "IX_ris_t_bakasha_fk_kod_status_bakasha_lehasava");

                entity.HasIndex(e => e.KodStatusHabakasha, "IX_ris_t_bakasha_kod_status_habakasha");

                entity.HasIndex(e => e.KodStatusHagasha, "IX_ris_t_bakasha_kod_status_hagasha");

                entity.HasIndex(e => e.SugBakashaRishaionHeiter, "IX_ris_t_bakasha_sug_bakasha_rishaion_heiter");

                entity.Property(e => e.PkCodeBakasha).HasColumnName("PK_code_bakasha");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkKodStatusBakashaLehasava).HasColumnName("fk_kod_status_bakasha_lehasava");

                entity.Property(e => e.Heara).HasColumnName("heara");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KSibaIBchiratEssekKodem).HasColumnName("k_siba_i_bchirat_essek_kodem");

                entity.Property(e => e.KodStatusHabakasha).HasColumnName("kod_status_habakasha");

                entity.Property(e => e.KodStatusHagasha).HasColumnName("kod_status_hagasha");

                entity.Property(e => e.MeidaMikdami).HasColumnName("meida_mikdami");

                entity.Property(e => e.MishtameshMevatel).HasColumnName("mishtamesh_mevatel");

                entity.Property(e => e.MisparBakasha).HasColumnName("mispar_bakasha");

                entity.Property(e => e.MisparHagasha).HasColumnName("mispar_hagasha");

                entity.Property(e => e.Mvutal).HasColumnName("mvutal");

                entity.Property(e => e.NidrashOrech).HasColumnName("nidrash_orech");

                entity.Property(e => e.PkCodeEssek).HasColumnName("PK_code_essek");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ShetachPargod)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("shetach_pargod");

                entity.Property(e => e.SibatBitul).HasColumnName("sibat_bitul");

                entity.Property(e => e.SugBakashaRishaionHeiter).HasColumnName("sug_bakasha_rishaion_heiter");

                entity.Property(e => e.SwReforma).HasColumnName("sw_reforma");

                entity.Property(e => e.SwShinuiMivneBuza).HasColumnName("sw_shinui_mivne_buza");

                entity.Property(e => e.SwTatzhir).HasColumnName("sw_tatzhir");

                entity.Property(e => e.TaarichBitul).HasColumnName("taarich_bitul");

                entity.Property(e => e.TaarichHagashatHabakasha).HasColumnName("taarich_hagashat_habakasha");

                entity.Property(e => e.TaarichPtira).HasColumnName("taarich_ptira");

                entity.Property(e => e.TaarichSiumTipul).HasColumnName("taarich_sium_tipul");

                entity.Property(e => e.TeudatZehutMagish).HasColumnName("teudat_zehut_magish");

                entity.Property(e => e.TrStatusHagasha).HasColumnName("tr_status_hagasha");
            });

            modelBuilder.HasSequence<int>("AdditionalPermitNumberSeq");

            modelBuilder.HasSequence<int>("CallNumberSeq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
