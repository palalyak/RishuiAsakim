using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class SeruvLaTahanaContext : DbContext
    {
        public SeruvLaTahanaContext()
        {
        }

        public SeruvLaTahanaContext(DbContextOptions<SeruvLaTahanaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTxSeruvLetachana> RisTxSeruvLetachanas { get; set; }
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
            modelBuilder.Entity<RisTxSeruvLetachana>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ris_tx_seruv_letachana");

                entity.HasIndex(e => e.FkSeruv, "IX_ris_tx_seruv_letachana_fk_seruv");

                entity.HasIndex(e => e.FkTachanaMeasheret, "IX_ris_tx_seruv_letachana_fk_tachana_measheret");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkSeruv).HasColumnName("fk_seruv");

                entity.Property(e => e.FkTachanaMeasheret).HasColumnName("fk_tachana_measheret");

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
