using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{

    public class ProductEntity
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryID { get; set; }
        public CategoryEntity Category { get; set; }
        public virtual ICollection<StockProductEntity> StockProducts { get; set; }
        public virtual ICollection<ProductInvoiceLineEntity> ProductInvoiceLineEntities { get; set; }


    }
}
