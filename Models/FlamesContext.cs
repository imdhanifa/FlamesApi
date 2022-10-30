using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSIT.Flames.Api.Models
{
    public partial class FlamesContext : DbContext
    {
        public FlamesContext()
        {
        }

        public FlamesContext(DbContextOptions<FlamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataDetails> DataDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=HANIFA;Database=Flames;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataDetails>(entity =>
            {
                entity.HasKey(e => e.Si);

                entity.ToTable("Data_Details");

                entity.Property(e => e.Si).HasColumnName("SI");

                entity.Property(e => e.Bname).HasColumnName("BName");

                entity.Property(e => e.Gname).HasColumnName("GName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
