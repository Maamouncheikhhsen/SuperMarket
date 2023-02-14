using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class CustomerEntity
    {
        public Guid CustomerID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<InvoiceEntity> Invoices { get; set; }
    }

}
