using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class ProductInvoiceLineEntity
    {
        public Guid ProductID { get; set; }   
        public ProductEntity Product { get; set; }

        public Guid InvoiceLineID { get; set; }     
        public InvoiceLineEntity InvoiceLine { get; set; }
    }
}
