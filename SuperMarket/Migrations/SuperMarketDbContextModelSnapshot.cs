﻿// <auto-generated />
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperMarket.Data;

#nullable disable

namespace SuperMarket.Migrations
{
    [DbContext(typeof(SuperMarketDbContext))]
    partial class SuperMarketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SuperMarket.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryID")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

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

                    b.HasKey("CustomerID")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

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

                    b.HasKey("InvoiceID")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

                    b.HasIndex("CustomerID");

                    b.HasIndex("PayID")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceLineEntity", b =>
                {
                    b.Property<Guid>("InvoiceLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InvoiceLineID")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

                    b.HasIndex("InvoiceID");

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

                    b.HasKey("PayID")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

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

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SuperMarket.Entities.ProductInvoiceLineEntity", b =>
                {
                    b.Property<Guid>("InvoiceLineID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InvoiceLineID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductInvoiceLineEntity");
                });

            modelBuilder.Entity("SuperMarket.Entities.StockEntity", b =>
                {
                    b.Property<Guid>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("StockID");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("SuperMarket.Entities.StockProductEntity", b =>
                {
                    b.Property<Guid>("StockID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StockID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("StockProducts");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.CustomerEntity", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Entities.PayEntity", "Pay")
                        .WithOne("Invoice")
                        .HasForeignKey("SuperMarket.Entities.InvoiceEntity", "PayID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Pay");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceLineEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.InvoiceEntity", "Invoice")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
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

            modelBuilder.Entity("SuperMarket.Entities.ProductInvoiceLineEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.InvoiceLineEntity", "InvoiceLine")
                        .WithMany("ProductInvoiceLineEntities")
                        .HasForeignKey("InvoiceLineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Entities.ProductEntity", "Product")
                        .WithMany("ProductInvoiceLineEntities")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceLine");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SuperMarket.Entities.StockProductEntity", b =>
                {
                    b.HasOne("SuperMarket.Entities.ProductEntity", "Product")
                        .WithMany("StockProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuperMarket.Entities.StockEntity", "Stock")
                        .WithMany("StockProducts")
                        .HasForeignKey("StockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("SuperMarket.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SuperMarket.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceEntity", b =>
                {
                    b.Navigation("InvoiceLines");
                });

            modelBuilder.Entity("SuperMarket.Entities.InvoiceLineEntity", b =>
                {
                    b.Navigation("ProductInvoiceLineEntities");
                });

            modelBuilder.Entity("SuperMarket.Entities.PayEntity", b =>
                {
                    b.Navigation("Invoice")
                        .IsRequired();
                });

            modelBuilder.Entity("SuperMarket.Entities.ProductEntity", b =>
                {
                    b.Navigation("ProductInvoiceLineEntities");

                    b.Navigation("StockProducts");
                });

            modelBuilder.Entity("SuperMarket.Entities.StockEntity", b =>
                {
                    b.Navigation("StockProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
