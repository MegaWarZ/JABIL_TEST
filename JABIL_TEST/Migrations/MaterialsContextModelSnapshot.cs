﻿// <auto-generated />
using System;
using JABIL_TEST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JABIL_TEST.Migrations
{
    [DbContext(typeof(MaterialsContext))]
    partial class MaterialsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JABIL_TEST.Models.Building", b =>
                {
                    b.Property<int>("Pkbuilding")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKBuilding");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pkbuilding"), 1L, 1);

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<string>("Building1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Building");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<int>("LastUser")
                        .HasColumnType("int");

                    b.HasKey("Pkbuilding");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("JABIL_TEST.Models.Customer", b =>
                {
                    b.Property<int>("Pkcustomers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKCustomers");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pkcustomers"), 1L, 1);

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<string>("Customer1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Customer");

                    b.Property<int>("Fkbuilding")
                        .HasColumnType("int")
                        .HasColumnName("FKBuilding");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<int>("LastUser")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Pkcustomers");

                    b.HasIndex("Fkbuilding");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("JABIL_TEST.Models.PartNumber", b =>
                {
                    b.Property<int>("PkpartNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKPartNumber");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkpartNumber"), 1L, 1);

                    b.Property<int>("Available")
                        .HasColumnType("int");

                    b.Property<int>("Fkcustomer")
                        .HasColumnType("int")
                        .HasColumnName("FKCustomer");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime");

                    b.Property<int>("LastUser")
                        .HasColumnType("int");

                    b.Property<string>("PartNumber1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PartNumber");

                    b.HasKey("PkpartNumber");

                    b.HasIndex("Fkcustomer");

                    b.ToTable("PartNumbers");
                });

            modelBuilder.Entity("JABIL_TEST.Models.Customer", b =>
                {
                    b.HasOne("JABIL_TEST.Models.Building", "FkbuildingNavigation")
                        .WithMany("Customers")
                        .HasForeignKey("Fkbuilding")
                        .IsRequired()
                        .HasConstraintName("FK_Customers_Buildings");

                    b.Navigation("FkbuildingNavigation");
                });

            modelBuilder.Entity("JABIL_TEST.Models.PartNumber", b =>
                {
                    b.HasOne("JABIL_TEST.Models.Customer", "FkcustomerNavigation")
                        .WithMany("PartNumbers")
                        .HasForeignKey("Fkcustomer")
                        .IsRequired()
                        .HasConstraintName("FK_PartNumbers_Customers");

                    b.Navigation("FkcustomerNavigation");
                });

            modelBuilder.Entity("JABIL_TEST.Models.Building", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("JABIL_TEST.Models.Customer", b =>
                {
                    b.Navigation("PartNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}