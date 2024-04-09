using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Infrastructure.ModelsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class SeruvContext : DbContext
    {
        public SeruvContext()
        {
        }

        public SeruvContext(DbContextOptions<SeruvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTSeruv> RisTSeruvs { get; set; }

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
            modelBuilder.Entity<RisTSeruv>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ris_t_seruv");

                entity.HasIndex(e => e.LuRefuseTypeCode, "IX_ris_t_seruv_LuRefuseTypeCode");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.AimTipulBeseruvSium).HasColumnName("Aim_tipul_beseruv_sium");

                entity.Property(e => e.CodeHachlatatShimua).HasColumnName("code_hachlatat_shimua");

                entity.Property(e => e.CodeSiumTipulShimua).HasColumnName("code_sium_tipul_shimua");

                entity.Property(e => e.CodeTozzatTeumShimua).HasColumnName("code_tozzat_teum_shimua");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SugSeruv).HasColumnName("sug_seruv");

                entity.Property(e => e.TaarichHasiruvHamakori)
                    .HasColumnName("taarich_hasiruv_hamakori")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.TaarichIdkunAcharon).HasColumnName("taarich_idkun_acharon");

                entity.Property(e => e.TaarichLabitulAlpiShimoa)
                    .HasColumnName("taarich_labitul_alpi_shimoa")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.TaarichLabitulHeiterimAlpiShimoa).HasColumnName("taarich_labitul_heiterim_alpi_shimoa");

                entity.Property(e => e.TaarichLebitulRishayon).HasColumnName("taarich_lebitul_rishayon");

                entity.Property(e => e.TaarichMakoriLabitulRishion)
                    .HasColumnName("taarich_makori_labitul_rishion")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.TaarichShimuaBefoal).HasColumnName("taarich_shimua_befoal");

                entity.Property(e => e.TaarichShimuaMetuchnan).HasColumnName("taarich_shimua_metuchnan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
