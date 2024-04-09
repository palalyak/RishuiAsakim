using System;
using System.Collections.Generic;
using Infrastructure.ModelsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class ShcavotGisIroniContext : DbContext
    {
        public ShcavotGisIroniContext()
        {
        }

        public ShcavotGisIroniContext(DbContextOptions<ShcavotGisIroniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTShcavotGisIroni> RisTShcavotGisIronis { get; set; }

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
            modelBuilder.Entity<RisTShcavotGisIroni>(entity =>
            {
                entity.HasKey(e => e.PkShcavotGisIroni);

                entity.ToTable("ris_t_shcavot_GIS_ironi");

                entity.HasIndex(e => e.FkEzorYafo, "IX_ris_t_shcavot_GIS_ironi_fk_ezor_yafo");

                entity.HasIndex(e => e.FkMediniutLaila, "IX_ris_t_shcavot_GIS_ironi_fk_mediniut_laila");

                entity.HasIndex(e => e.FkMitcham, "IX_ris_t_shcavot_GIS_ironi_fk_mitcham");

                entity.Property(e => e.PkShcavotGisIroni)
                    .ValueGeneratedNever()
                    .HasColumnName("pk_shcavot_GIS_ironi");

                entity.Property(e => e.ChotzeRechovMercazi).HasColumnName("chotze_rechov_mercazi");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkEzorYafo).HasColumnName("fk_ezor_yafo");

                entity.Property(e => e.FkMediniutLaila).HasColumnName("fk_mediniut_laila");

                entity.Property(e => e.FkMitcham).HasColumnName("fk_mitcham");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MisparBait).HasColumnName("mispar_bait");

                entity.Property(e => e.MisparEzor).HasColumnName("mispar_ezor");

                entity.Property(e => e.MisparKnisot).HasColumnName("mispar_knisot");

                entity.Property(e => e.Rechov).HasColumnName("rechov");

                entity.Property(e => e.RechovMercazi).HasColumnName("rechov_mercazi");

                entity.Property(e => e.RechovMischari).HasColumnName("rechov_mischari");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
