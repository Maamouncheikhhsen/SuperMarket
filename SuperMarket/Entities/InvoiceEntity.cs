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

        public Guid PayID { get; set; }

    }





}



