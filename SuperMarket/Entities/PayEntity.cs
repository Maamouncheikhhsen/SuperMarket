using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Entities
{
    
    public class PayEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PayID { get; set; }

        [Required]
        public DateTime PayDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public virtual InvoiceEntity Invoices { get; set; }
    }

}
