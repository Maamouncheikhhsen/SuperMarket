using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class ProductInvoiceLineEntity
    {
        [Key]
        public Guid ProductInvoiceLineID { get; set; }
        public Guid ProductID { get; set; }
        [ForeignKey (nameof(ProductID))]
        public ProductEntity Product { get; set; }

        public Guid InvoiceLineID { get; set; }
        [ForeignKey(nameof(InvoiceLineID))]
        public InvoiceLineEntity InvoiceLine { get; set; }
    }
}
