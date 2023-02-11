using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Entities
{
    public class InvoiceLineEntity
    {
        public Guid InvoiceLineID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Guid ProductID { get; set; }

        public Guid InvoiceID { get; set; }

    }
}
