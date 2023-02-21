using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities
{
    public class InvoiceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InvoiceID { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        //[Required]
        public Guid CustomerID { get; set; }

        [ForeignKey(nameof(CustomerID))]
        public CustomerEntity Customer { get; set; }

       // [Required]
        public Guid PayID { get; set; }

        [ForeignKey(nameof(PayID))]
        public PayEntity Pay { get; set; }

        public virtual ICollection<InvoiceLineEntity> InvoiceLines { get; set; } = new List<InvoiceLineEntity>();

    }





}



