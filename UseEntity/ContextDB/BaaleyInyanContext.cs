using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class BaaleyInyanContext : DbContext
    {
        public BaaleyInyanContext()
        {
        }

        public BaaleyInyanContext(DbContextOptions<BaaleyInyanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTBaaleyInyan> RisTBaaleyInyans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if (DEBUG)

                optionsBuilder.UseSqlServer("Data Source=SQLDEV1902;Initial Catalog=db950_bi;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;");

#else
                optionsBuilder.UseSqlServer("Data Source=SQLTST1902;Initial Catalog=db950_bi;User Id=db950_t;Password=h#247950;TrustServerCertificate=True;");

#endif
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RisTBaaleyInyan>(entity =>
            {
                entity.HasKey(e => e.PkMezaheBaalInyan);

                entity.ToTable("ris_t_baaley_inyan");

                entity.Property(e => e.PkMezaheBaalInyan).HasColumnName("pk_mezahe_baal_inyan");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkSemelMegurim).HasColumnName("fk_semel_megurim");

                entity.Property(e => e.FkSemelYeshuv).HasColumnName("fk_semel_yeshuv");

                entity.Property(e => e.FkSugZihui).HasColumnName("fk_sug_zihui");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MisparBait).HasColumnName("mispar_bait");

                entity.Property(e => e.MisparKnisa).HasColumnName("mispar_knisa");

                entity.Property(e => e.MisparKuma).HasColumnName("mispar_kuma");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ShemChevra).HasColumnName("shem_chevra");

                entity.Property(e => e.ShemMispaha).HasColumnName("shem_mispaha");

                entity.Property(e => e.ShemPrati).HasColumnName("shem_prati");

                entity.Property(e => e.TarichPtira).HasColumnName("tarich_ptira");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
