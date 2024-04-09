using System;
using System.Collections.Generic;
using Infrastructure.ModelsDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.ContextDB
{
    public partial class MaarechetParameterContext : DbContext
    {
        public MaarechetParameterContext()
        {
        }

        public MaarechetParameterContext(DbContextOptions<MaarechetParameterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RisTtMaarechetParameter> RisTtMaarechetParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if (DEBUG)
                optionsBuilder.UseSqlServer("Data Source=SQLDEV1902;Initial Catalog=db950_tashtit;User Id=db950_d;Password=h#649950;TrustServerCertificate=True;");


#else
                optionsBuilder.UseSqlServer("Data Source=SQLTST1902;Initial Catalog=db950_tashtit;User Id=db950_t;Password=h#247950;TrustServerCertificate=True;");

#endif
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RisTtMaarechetParameter>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("ris_tt_maarechet_parameter");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ErechParameter)
                    .IsRequired()
                    .HasColumnName("erech_parameter");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SugParameter).HasColumnName("sug_parameter");

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
