using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Entities
{   

    public class PayEntity
    {
        public Guid PayID { get; set; }
        public DateTime PayDate { get; set; }
        public decimal Amount { get; set; }

        public virtual InvoiceEntity Invoice { get; set; }

    }

}
