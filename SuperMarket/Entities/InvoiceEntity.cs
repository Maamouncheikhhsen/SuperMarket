using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities
{
    public class InvoiceEntity
    {
        public Guid InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid CustomerID { get; set; }
        public CustomerEntity Customer { get; set; }
        public Guid PayID { get; set; }
        public PayEntity Pay { get; set; }
        public virtual ICollection<InvoiceLineEntity> InvoiceLines { get; set; }

    }





}



