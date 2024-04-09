using System;
using System.Collections.Generic;
using Infrastructure.ModelsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{ 
    public partial class MautBrishayonLeesekContext : DbContext
    {
        public MautBrishayonLeesekContext()
        {
        }

        public MautBrishayonLeesekContext(DbContextOptions<MautBrishayonLeesekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTMautBrishayonLeesek> RisTMautBrishayonLeeseks { get; set; }

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
            modelBuilder.Entity<RisTMautBrishayonLeesek>(entity =>
            {
                entity.HasKey(e => e.PkMautRisahyunEsek);

                entity.ToTable("ris_t_maut_brishayon_leesek");

                entity.HasIndex(e => e.FkMautBakasha, "IX_ris_t_maut_brishayon_leesek_Fk_maut_bakasha");

                entity.Property(e => e.PkMautRisahyunEsek).HasColumnName("Pk_maut_risahyun_esek");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkMautBakasha).HasColumnName("Fk_maut_bakasha");

                entity.Property(e => e.FkRishyunEsek).HasColumnName("Fk_rishyun_esek");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Mevutal).HasColumnName("mevutal");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SugRishayon).HasColumnName("sug_rishayon");

                entity.Property(e => e.TaarichPkiatShimushChoreg).HasColumnName("taarich_pkiat_shimush_choreg");

                entity.Property(e => e.TaarichSyumTokefHarishaion).HasColumnName("taarich_syum_tokef_harishaion");

                entity.Property(e => e.TaarichTchilatTokefHarishaion).HasColumnName("taarich_tchilat_tokef_harishaion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
