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
        public virtual DbSet<EmployeeMst> EmployeeMst { get; set; } = null!;
        public virtual DbSet<PickUpRequest> PickUpRequests { get; set; } = null!;
        public virtual DbSet<LocationPoint> LocationPoints { get; set; } = null!;
        public virtual DbSet<DailyWeight> DailyWeight { get; set; } = null!;
        public virtual DbSet<LookupMst> LookupMst { get; set; } = null!;


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
            
            modelBuilder.Entity<LocationPoint>(entity =>
            {
                entity.HasKey(e => e.LocationID);

                entity.ToTable("LocationPoint");

                entity.Property(e => e.LocationID).HasColumnName("LocationID");

                entity.Property(e => e.Latitude).HasMaxLength(200);
                entity.Property(e => e.Longitude).HasMaxLength(200);
                entity.Property(e => e.LocationName).HasMaxLength(200);
                entity.Property(e => e.Remark).HasMaxLength(200);
                entity.Property(e => e.IsActive).HasMaxLength(200);
                entity.Property(e => e.CreatedByID).HasMaxLength(200);
                entity.Property(e => e.DateCreated).HasMaxLength(200);
                entity.Property(e => e.ModifiedByID).HasMaxLength(200);
                entity.Property(e => e.DateModified).HasMaxLength(200);
            });
            modelBuilder.Entity<UserMst>(entity =>
            {
                entity.HasKey(e => e.UserID);
                
                entity.ToTable("UserMst");

                entity.Property(e => e.UserID).HasColumnName("UserID");
                entity.Property(e => e.EmployeeID).HasMaxLength(200);
                entity.Property(e => e.UserName).HasMaxLength(200);
                entity.Property(e => e.EmailAddress).HasMaxLength(200);
                entity.Property(e => e.Password).HasMaxLength(200);
                entity.Property(e => e.RoleID).HasMaxLength(200);
                entity.Property(e => e.IsActive).HasMaxLength(200);
                entity.Property(e => e.IsLocked).HasMaxLength(200);
                entity.Property(e => e.CreatedByID).HasMaxLength(200);
                entity.Property(e => e.DateCreated).HasMaxLength(200);
                entity.Property(e => e.ModifiedByID).HasMaxLength(200);
                entity.Property(e => e.DateModified).HasMaxLength(200);
            });
            modelBuilder.Entity<DailyWeight>(entity =>
            {
                entity.HasKey(e => e.WeightID);

                entity.ToTable("DailyWeight");

                entity.Property(e => e.WeightID).HasColumnName("WeightID");
                entity.Property(e => e.Date).HasMaxLength(200);
                entity.Property(e => e.TruckNumber).HasMaxLength(200);
                entity.Property(e => e.DriverID).HasMaxLength(200);
                entity.Property(e => e.ArrivelTime).HasMaxLength(200);
                entity.Property(e => e.ZoneLocation).HasMaxLength(200);
                entity.Property(e => e.Weight).HasMaxLength(200);
                entity.Property(e => e.TruckWeight).HasMaxLength(200);
                entity.Property(e => e.OtherWeight).HasMaxLength(200);
                entity.Property(e => e.FinalWeight).HasMaxLength(200);
                entity.Property(e => e.NumberOfBox).HasMaxLength(200);
                entity.Property(e => e.CreatedByID).HasMaxLength(200);
                entity.Property(e => e.DateCreated).HasMaxLength(200);
                entity.Property(e => e.ModifiedByID).HasMaxLength(200);
                entity.Property(e => e.DateModified).HasMaxLength(200);
            });

            modelBuilder.Entity<PickUpRequest>(entity =>
            {
                entity.HasKey(e => e.PickupID);

                entity.ToTable("PickUpRequest");

                entity.Property(e => e.PickupID).HasColumnName("PickupID");
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.Address).HasMaxLength(200);
                entity.Property(e => e.MobileNo).HasMaxLength(200);
                entity.Property(e => e.PickupDateTime).HasMaxLength(200);
                entity.Property(e => e.DonateType).HasMaxLength(200);
                entity.Property(e => e.PickupLocation).HasMaxLength(200);
                entity.Property(e => e.PickupEmployeeID).HasMaxLength(200);
                entity.Property(e => e.IsPicked).HasMaxLength(200);
                entity.Property(e => e.CreatedByID).HasMaxLength(200);
                entity.Property(e => e.DateCreated).HasMaxLength(200);
                entity.Property(e => e.ModifiedByID).HasMaxLength(200);
                entity.Property(e => e.DateModified).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
