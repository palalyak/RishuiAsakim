using System;
using System.Collections.Generic;
using Infrastructure.ModelsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class SugHeiterNilveContext : DbContext
    {
        public SugHeiterNilveContext()
        {
        }

        public SugHeiterNilveContext(DbContextOptions<SugHeiterNilveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTtSugHeiterNilve> RisTtSugHeiterNilves { get; set; }

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
            modelBuilder.Entity<RisTtSugHeiterNilve>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("ris_tt_sug_heiter_nilve");

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkCodeTlutSugHeiterNilve).HasColumnName("fk_code_tlut_sug_heiter_nilve");

                entity.Property(e => e.FkKvuzatMaut).HasColumnName("fk_kvuzat_maut");

                entity.Property(e => e.FkSugAvodotTashtit).HasColumnName("fk_sug_avodot_tashtit");

                entity.Property(e => e.HimNidrashTashlumHagra).HasColumnName("him_nidrash_tashlum_hagra");

                entity.Property(e => e.HimTaloiBerishaion).HasColumnName("him_taloi_berishaion");

                entity.Property(e => e.IpAddress).HasMaxLength(15);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MisparChodashiomLechidush).HasColumnName("mispar_chodashiom_lechidush");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SugCheadush).HasColumnName("sug_cheadush");

                entity.Property(e => e.TarichSiomHiter).HasColumnName("tarich_siom_hiter");

                entity.Property(e => e.TarichSiomOnatHiter).HasColumnName("tarich_siom_onat_hiter");

                entity.Property(e => e.TarichTchilatHiter).HasColumnName("tarich_tchilat_hiter");

                entity.Property(e => e.TarichTchilatOnatHiter).HasColumnName("tarich_tchilat_onat_hiter");

                entity.Property(e => e.Teur)
                    .IsRequired()
                    .HasColumnName("teur");

                entity.Property(e => e.TkufatHiterMax).HasColumnName("tkufat_hiter_max");

                entity.Property(e => e.TkufatHiterMin).HasColumnName("tkufat_hiter_min");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
