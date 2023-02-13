using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;

namespace SuperMarket.Data
{
    public class SuperMarketDbContext :DbContext
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
    }
}
