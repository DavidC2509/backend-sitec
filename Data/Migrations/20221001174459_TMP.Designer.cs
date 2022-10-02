﻿// <auto-generated />
using System;
using Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Command.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20221001174459_TMP")]
    partial class TMP
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Entities.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nProductId");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sBarCode");

                    b.Property<DateTime>("Computed")
                        .HasColumnType("datetime")
                        .HasColumnName("dCompDate");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("sDescripcion");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sName");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("nPrice");

                    b.Property<double>("PriceIva")
                        .HasColumnType("double")
                        .HasColumnName("nPriceIva");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("bStatus");

                    b.Property<int>("UserCode")
                        .HasColumnType("int")
                        .HasColumnName("nUsercode");

                    b.HasKey("Id");

                    b.ToTable("fassil_Product");
                });

            modelBuilder.Entity("Domain.Entities.WarehouseAggregate.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nWarehouseId");

                    b.Property<DateTime>("Computed")
                        .HasColumnType("datetime")
                        .HasColumnName("dCompDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sName");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sPlace");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("bStatus");

                    b.Property<int>("UserCode")
                        .HasColumnType("int")
                        .HasColumnName("nUsercode");

                    b.HasKey("Id");

                    b.ToTable("fassil_Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.WarehouseProductAggregate.WarehouseProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nWarehouseProductId");

                    b.Property<DateTime>("Computed")
                        .HasColumnType("datetime")
                        .HasColumnName("dCompDate");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("nCount");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("nProductId");

                    b.Property<int>("UserCode")
                        .HasColumnType("int")
                        .HasColumnName("nUsercode");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int")
                        .HasColumnName("nWarehouseId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("fassil_WarehouseProduct");
                });

            modelBuilder.Entity("Domain.Entities.WarehouseProductAggregate.WarehouseProductSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("nWarehouseProductSale");

                    b.Property<DateTime>("Computed")
                        .HasColumnType("datetime")
                        .HasColumnName("dCompDate");

                    b.Property<int>("CountSell")
                        .HasColumnType("int")
                        .HasColumnName("nCountSell");

                    b.Property<DateTime>("DateSell")
                        .HasColumnType("datetime")
                        .HasColumnName("dDateSell");

                    b.Property<double>("PriceSell")
                        .HasColumnType("double")
                        .HasColumnName("nPriceSell");

                    b.Property<int>("UserCode")
                        .HasColumnType("int")
                        .HasColumnName("nUsercode");

                    b.Property<int>("WarehouseProductId")
                        .HasColumnType("int")
                        .HasColumnName("nWarehouseProductId");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseProductId");

                    b.ToTable("fassil_WarehouseProductSale");
                });

            modelBuilder.Entity("Domain.Entities.WarehouseProductAggregate.WarehouseProduct", b =>
                {
                    b.HasOne("Domain.Entities.ProductAggregate.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.WarehouseAggregate.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Domain.Entities.WarehouseProductAggregate.WarehouseProductSale", b =>
                {
                    b.HasOne("Domain.Entities.WarehouseProductAggregate.WarehouseProduct", null)
                        .WithMany("WarehouseProductSale")
                        .HasForeignKey("WarehouseProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.WarehouseProductAggregate.WarehouseProduct", b =>
                {
                    b.Navigation("WarehouseProductSale");
                });
#pragma warning restore 612, 618
        }
    }
}
