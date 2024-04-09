using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class RishayonLeesekContext : DbContext
    {
        public RishayonLeesekContext()
        {
        }

        public RishayonLeesekContext(DbContextOptions<RishayonLeesekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTRishayonLeesek> RisTRishayonLeeseks { get; set; }

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
            modelBuilder.Entity<RisTRishayonLeesek>(entity =>
            {
                entity.HasKey(e => e.PkRishiunEsek);

                entity.ToTable("ris_t_rishayon_leesek");

                entity.HasIndex(e => e.FkBakasha, "IX_ris_t_rishayon_leesek_fk_bakasha");

                entity.HasIndex(e => e.FkCodeShovarTashlumRishayon, "IX_ris_t_rishayon_leesek_fk_code_shovar_tashlum_rishayon");

                entity.HasIndex(e => e.FkStatusRishayun, "IX_ris_t_rishayon_leesek_fk_status_rishayun");

                entity.Property(e => e.PkRishiunEsek).HasColumnName("pk_rishiun_esek");

                entity.Property(e => e.ChidushBeikvotMahut).HasColumnName("chidush_beikvot_mahut");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EssekBesikun).HasColumnName("essek_besikun");

                entity.Property(e => e.FkBakasha).HasColumnName("fk_bakasha");

                entity.Property(e => e.FkCodeBakasha).HasColumnName("fk_code_bakasha");

                entity.Property(e => e.FkCodeEssek).HasColumnName("fk_code_essek");

                entity.Property(e => e.FkCodeShovarTashlumRishayon).HasColumnName("fk_code_shovar_tashlum_rishayon");

                entity.Property(e => e.FkRishayun).HasColumnName("fk_rishayun");

                entity.Property(e => e.FkSibatBitul).HasColumnName("Fk_sibat_bitul");

                entity.Property(e => e.FkStatusRishayun).HasColumnName("fk_status_rishayun");

                entity.Property(e => e.FkSugTufes).HasColumnName("fk_sug_tufes");

                entity.Property(e => e.Heara).HasColumnName("heara");

                entity.Property(e => e.HidushBeikvotChariga).HasColumnName("hidush_beikvot_chariga");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.KavanaLebitul).HasColumnName("kavana_lebitul");

                entity.Property(e => e.Mevutal).HasColumnName("mevutal");

                entity.Property(e => e.MishtameshMevatel).HasColumnName("mishtamesh_mevatel");

                entity.Property(e => e.MisparRishaionLetetzuga).HasColumnName("mispar_rishaion_letetzuga");

                entity.Property(e => e.MisparRishayun).HasColumnName("mispar_rishayun");

                entity.Property(e => e.NidrashTashlumHagra).HasColumnName("Nidrash_tashlum_hagra");

                entity.Property(e => e.PursamShimushCchoreg).HasColumnName("pursam_shimush_cchoreg");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TaarichBitulRishyun).HasColumnName("Taarich_bitul_rishyun");

                entity.Property(e => e.TaarichKabalatRishaion).HasColumnName("taarich_kabalat_rishaion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
