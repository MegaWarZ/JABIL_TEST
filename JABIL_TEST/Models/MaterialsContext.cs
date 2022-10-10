using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JABIL_TEST.Models
{
    public partial class MaterialsContext : DbContext
    {
        public MaterialsContext()
        {
        }

        public MaterialsContext(DbContextOptions<MaterialsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<PartNumber> PartNumbers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MEGAPC; Database=Materials;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.Pkbuilding);

                entity.Property(e => e.Pkbuilding).HasColumnName("PKBuilding");

                entity.Property(e => e.Building1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Building");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Pkcustomers);

                entity.Property(e => e.Pkcustomers).HasColumnName("PKCustomers");

                entity.Property(e => e.Customer1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer");

                entity.Property(e => e.Fkbuilding).HasColumnName("FKBuilding");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkbuildingNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Fkbuilding)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customers_Buildings");
            });

            modelBuilder.Entity<PartNumber>(entity =>
            {
                entity.HasKey(e => e.PkpartNumber);

                entity.Property(e => e.PkpartNumber).HasColumnName("PKPartNumber");

                entity.Property(e => e.Fkcustomer).HasColumnName("FKCustomer");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.PartNumber1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PartNumber");

                entity.HasOne(d => d.FkcustomerNavigation)
                    .WithMany(p => p.PartNumbers)
                    .HasForeignKey(d => d.Fkcustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartNumbers_Customers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
