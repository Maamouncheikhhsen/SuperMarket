using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;

namespace SuperMarket.Data;

public partial class SuperMarketDataBaseFirstContext : DbContext
{
    public SuperMarketDataBaseFirstContext()
    {
    }

    public SuperMarketDataBaseFirstContext(DbContextOptions<SuperMarketDataBaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInvoiceLineEntity> ProductInvoiceLineEntities { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockProduct> StockProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=SuperMarketConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.InvoiceID).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.Property(e => e.InvoiceLineID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.Property(e => e.PayID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductID).ValueGeneratedNever();
        });

        modelBuilder.Entity<ProductInvoiceLineEntity>(entity =>
        {
            entity.Property(e => e.ProductInvoiceLineID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.Property(e => e.StockID).ValueGeneratedNever();
        });

        modelBuilder.Entity<StockProduct>(entity =>
        {
            entity.Property(e => e.StockProductID).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
