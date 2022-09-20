using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingReportLibrary.Models
{
    public partial class TrainingServiceBookingContext : DbContext
    {
        public TrainingServiceBookingContext()
        {
        }

        public TrainingServiceBookingContext(DbContextOptions<TrainingServiceBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appservicerequest> Appservicerequests { get; set; } = null!;
        public virtual DbSet<Appservicerequestreport> Appservicerequestreports { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.9.246.162,4022;Database=TrainingServiceBooking;User ID=Sa;pwd=CreateFile();");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appservicerequest>(entity =>
            {
                entity.ToTable("APPSERVICEREQUEST");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Problem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROBLEM");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Reqdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Appservicerequests)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPSERVICEREQUEST_PRODUCTS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Appservicerequests)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPSERVICEREQUEST_USERS");
            });

            modelBuilder.Entity<Appservicerequestreport>(entity =>
            {
                entity.ToTable("APPSERVICEREQUESTREPORT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Actiontaken)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ACTIONTAKEN");

                entity.Property(e => e.Diagnosticdetails)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DIAGNOSTICDETAILS");

                entity.Property(e => e.Ispaid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISPAID")
                    .IsFixedLength();

                entity.Property(e => e.Repairdetails)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REPAIRDETAILS");

                entity.Property(e => e.Reportdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTDATE");

                entity.Property(e => e.Servicereqid).HasColumnName("SERVICEREQID");

                entity.Property(e => e.Servicetype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SERVICETYPE");

                entity.Property(e => e.Visitfees)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("VISITFEES");

                entity.HasOne(d => d.Servicereq)
                    .WithMany(p => p.Appservicerequestreports)
                    .HasForeignKey(d => d.Servicereqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPSERVICEREQUESTREPORT_APPSERVICEREQUEST");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("COST");

                entity.Property(e => e.Createddate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Make)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAKE");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MODEL");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("USERS");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.Createddate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOBILE");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Usename)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USENAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
