using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Entities
{
    public class InvoiceLineEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InvoiceLineID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public virtual ICollection<ProductInvoiceLineEntity> ProductInvoiceLineEntities { get; set; }

       // [Required]
        public Guid InvoiceID { get; set; }

        [ForeignKey(nameof(InvoiceID))]
        public InvoiceEntity Invoice { get; set; }

    }
}
