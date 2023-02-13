﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperMarket.Data;

#nullable disable

namespace SuperMarket.Migrations
{
    [DbContext(typeof(SuperMarketDbContext))]
    [Migration("20230211174340_InitialCreateDB")]
    partial class InitialCreateDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductEntityStockEntity", b =>
                {
                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StockID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductID", "StockID");

                    b.HasIndex("StockID");

                    b.ToTable("ProductEntityStockEntity");
                });

            modelBuilder.Entity("SuperMarket.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SuperMarket.Entities.CustomerEntity", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceEntity", b =>
                {
                    b.Property<Guid>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PayID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("PayID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceLineEntity", b =>
                {
                    b.Property<Guid>("InvoiceLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceLineID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ProductID");

                    b.ToTable("InvoiceLines");
                });

            modelBuilder.Entity("SuperMarket.Entities.PayEntity", b =>
                {
                    b.Property<Guid>("PayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PayID");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("SuperMarket.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("StockID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SuperMarket.Entities.StockEntity", b =>
                {
                    b.Property<Guid>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("StockID");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("ProductEntityStockEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.StockEntity", null)
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Entities.ProductEntity", null)
                        .WithMany()
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.CustomerEntity", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Entities.PayEntity", "Pay")
                        .WithMany("Invoices")
                        .HasForeignKey("PayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Pay");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceLineEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.InvoiceEntity", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Entities.ProductEntity", "Product")
                        .WithMany("InvoiceLine")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SuperMarket.Entities.ProductEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SuperMarket.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SuperMarket.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("SuperMarket.Entities.PayEntity", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("SuperMarket.Entities.ProductEntity", b =>
                {
                    b.Navigation("InvoiceLine");
                });
#pragma warning restore 612, 618
        }
    }
}
