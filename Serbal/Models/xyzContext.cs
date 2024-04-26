using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Serbal.Models
{
    public partial class xyzContext : DbContext
    {
        public xyzContext()
        {
        }

        public xyzContext(DbContextOptions<xyzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RoleMst> RoleMsts { get; set; } = null!;
        public virtual DbSet<UserMst> UserMsts { get; set; } = null!;
        public virtual DbSet<EmployeeMst> EmployeeMsts { get; set; } = null!;
        public virtual DbSet<PickUpRequest> PickUpRequests { get; set; } = null!;
        public virtual DbSet<LocationPoint> LocationPoints { get; set; } = null!;
        public virtual DbSet<DailyWeight> DailyWeights { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("server=DESKTOP-ODA2CFD; database=xyz; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMst>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleMst");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
