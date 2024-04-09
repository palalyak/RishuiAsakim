using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class SugTachanaMeasheretContext : DbContext
    {
        public SugTachanaMeasheretContext()
        {
        }

        public SugTachanaMeasheretContext(DbContextOptions<SugTachanaMeasheretContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTtSugTachanaMeasheret> RisTtSugTachanaMeasherets { get; set; }

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
            modelBuilder.Entity<RisTtSugTachanaMeasheret>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ris_tt_sug_tachana_measheret");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Hearot).HasColumnName("hearot");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MevatzaBikurim)
                    .IsRequired()
                    .HasColumnName("mevatza_bikurim")
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SwChizoni).HasColumnName("sw_chizoni");

                entity.Property(e => e.SwEnoMoneaRishayon).HasColumnName("sw_eno_monea_rishayon");

                entity.Property(e => e.SwLeafsherTnaiMukdam).HasColumnName("sw_leafsher_tnai_mukdam");

                entity.Property(e => e.Teur)
                    .IsRequired()
                    .HasColumnName("teur");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
