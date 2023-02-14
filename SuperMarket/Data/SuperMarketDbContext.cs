using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Data
{
    public class SuperMarketDbContext : DbContext
    {
        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> options)
           : base(options)
        { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<StockProductEntity> StockProducts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<InvoiceLineEntity> InvoiceLines { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<PayEntity> Pays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Fluent APIs of Category

            modelBuilder.Entity<CategoryEntity>()
               .HasKey(c => c.CategoryID)
               .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<CategoryEntity>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            //modelBuilder.Entity<CategoryEntity>()
            //    .HasMany(c => c.Products)
            //    .WithOne(p => p.Category);

            #endregion Fluent APIs of Category

            #region Fluent APIs of Customer

            modelBuilder.Entity<CustomerEntity>()
            .HasKey(c => c.CustomerID)
            .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<CustomerEntity>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<CustomerEntity>()
                .Property(c => c.Mail)
                .HasMaxLength(100);

            modelBuilder.Entity<CustomerEntity>()
                .Property(c => c.PhoneNumber)
                .HasMaxLength(20);

            //modelBuilder.Entity<CustomerEntity>()
            //    .HasMany(c => c.Invoices)
            //    .WithOne(i => i.Customer)
            //    .HasForeignKey(i => i.CustomerID);


            #endregion Fluent APIs of Customer

            #region Fluent APIs of Invoice

            modelBuilder.Entity<InvoiceEntity>()
                .HasKey(i => i.InvoiceID)
                .HasAnnotation("DatabaseGenerated",DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<InvoiceEntity>()
                 .Property(i => i.InvoiceDate)
                 .IsRequired();

            modelBuilder.Entity<InvoiceEntity>()
                .Property(i => i.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<InvoiceEntity>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerID)
                .IsRequired();

            modelBuilder.Entity<InvoiceEntity>()
                .HasOne(p => p.Pay)
                .WithOne(i => i.Invoice)
                .HasForeignKey<InvoiceEntity>(i => i.PayID);

            modelBuilder.Entity<InvoiceEntity>()
                .HasMany(il => il.InvoiceLines)
                .WithOne(i => i.Invoice)
                .HasForeignKey(i => i.InvoiceID);

            #endregion Fluent APIs of Invoice

            #region Fluent API of InvoiceLine

            modelBuilder.Entity<InvoiceLineEntity>()
                .HasKey(il => il.InvoiceLineID)
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<InvoiceLineEntity>()
                .Property(il => il.Quantity)
                .IsRequired();

            modelBuilder.Entity<InvoiceLineEntity>()
                .Property(il => il.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            //modelBuilder.Entity<InvoiceLineEntity>()
            //    .HasOne(i => i.Invoice)
            //    .WithMany(il => il.InvoiceLines)
            //    .HasForeignKey(i => i.InvoiceID);
            #endregion Fluent API of InvoiceLine

            #region Fluent API of ProductInvoiceLine

            modelBuilder.Entity<ProductInvoiceLineEntity>()
                .HasKey(p => new { p.InvoiceLineID, p.ProductID });

            modelBuilder.Entity<ProductInvoiceLineEntity>()
                .HasOne(p => p.InvoiceLine)
                .WithMany(i => i.ProductInvoiceLineEntities)
                .HasForeignKey(p => p.InvoiceLineID);

            modelBuilder.Entity<ProductInvoiceLineEntity>()
                .HasOne(p => p.Product)
                .WithMany(pr => pr.ProductInvoiceLineEntities)
                .HasForeignKey(p => p.ProductID);

            #endregion Fluent API of InvoiceLine

            #region Fluent API of Pay 

            modelBuilder.Entity<PayEntity>()
                .HasKey(p => p.PayID)
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PayEntity>()
                .Property (il => il.PayDate)
                .IsRequired();

            modelBuilder.Entity<PayEntity>()
                .Property(il => il.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            //modelBuilder.Entity<PayEntity>()
            //    .HasOne(i => i.Invoice)
            //    .WithOne(p => p.Pay)
            //    .HasForeignKey<InvoiceEntity>(i => i.PayID);

            #endregion

            #region Fluent API of Product
            modelBuilder.Entity<ProductEntity>()
                .HasKey(p => p.ProductID);

            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.ProductID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .IsRequired();


            //modelBuilder.Entity<ProductEntity>()
            //    .HasMany(p => p.StockProducts)
            //    .WithOne(sp => sp.Product)
            //    .HasForeignKey(sp => sp.ProductID)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ProductEntity>()
            //    .HasMany(p => p.ProductInvoiceLineEntities)
            //    .WithOne(pi => pi.Product)
            //    .HasForeignKey(pi => pi.ProductID)
            //    .OnDelete(DeleteBehavior.Cascade);

            #endregion Fluent API of Product


            #region StockEntity
            modelBuilder.Entity<StockEntity>()
                .HasKey(s => s.StockID);

            modelBuilder.Entity<StockEntity>()
                .Property(s => s.Quantity)
                .IsRequired();

            //modelBuilder.Entity<StockEntity>()
            //    .HasMany(p => p.StockProducts)
            //    .WithOne(sp => sp.Stock)
            //    .HasForeignKey(sp => sp.StockID)
            //    .OnDelete(DeleteBehavior.Cascade);

            #endregion  StockEntity

            #region StockProductEntity

            modelBuilder.Entity<StockProductEntity>()
                .HasKey(sp => new { sp.StockID, sp.ProductID });

            modelBuilder.Entity<StockProductEntity>()
                .HasOne(sp => sp.Stock)
                .WithMany(s => s.StockProducts)
                .HasForeignKey(sp => sp.StockID);

            modelBuilder.Entity<StockProductEntity>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.StockProducts)
                .HasForeignKey(sp => sp.ProductID);

            #endregion StockProductEntity




        }

    }
}
