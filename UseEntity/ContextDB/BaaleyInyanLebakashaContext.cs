using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class BaaleyInyanLebakashaContext : DbContext
    {
        public BaaleyInyanLebakashaContext()
        {
        }

        public BaaleyInyanLebakashaContext(DbContextOptions<BaaleyInyanLebakashaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTxBaaleyInyanLebakasha> RisTxBaaleyInyanLebakashas { get; set; }

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
            modelBuilder.Entity<RisTxBaaleyInyanLebakasha>(entity =>
            {
                entity.HasKey(e => e.PkCodeBaaleyInyanLebakasha);

                entity.ToTable("ris_tx_baaley_inyan_lebakasha");

                entity.Property(e => e.PkCodeBaaleyInyanLebakasha).HasColumnName("Pk_code_baaley_inyan_lebakasha");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkCodeBaaleyInyanBtik).HasColumnName("fk_code_baaley_inyan_btik");

                entity.Property(e => e.FkCodeBakasha).HasColumnName("fk_code_bakasha");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

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
