using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class BaaleyInyanBtikContext : DbContext
    {
        public BaaleyInyanBtikContext()
        {
        }

        public BaaleyInyanBtikContext(DbContextOptions<BaaleyInyanBtikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTxBaaleyInyanBtik> RisTxBaaleyInyanBtiks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConfigurationManager.ConnectionStrings["ConStr"];
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
            modelBuilder.Entity<RisTxBaaleyInyanBtik>(entity =>
            {
                entity.HasKey(e => e.PkBaaleyInyanBtik)
                    .HasName("PK_ris_t_baaley_inyan_btik");

                entity.ToTable("ris_tx_baaley_inyan_btik");

                entity.Property(e => e.PkBaaleyInyanBtik).HasColumnName("pk_baaley_inyan_btik");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DoarElectroni).HasColumnName("doar_electroni");

                entity.Property(e => e.FkCodeEssek).HasColumnName("fk_code_essek");

                entity.Property(e => e.FkMezaheBaalInyan)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("fk_Mezahe_baal_inyan");

                entity.Property(e => e.FkMisparBakashaBapamHarishona).HasColumnName("fk_mispar_bakasha_bapam_harishona");

                entity.Property(e => e.FkSugBaalInyan).HasColumnName("fk_sug_baal_inyan");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StakeholderId1).HasMaxLength(450);

                entity.Property(e => e.Telephone1).HasColumnName("Telephone_1");

                entity.Property(e => e.Telephone2).HasColumnName("Telephone_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
