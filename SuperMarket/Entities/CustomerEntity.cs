using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class CustomerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Mail { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public virtual ICollection<InvoiceEntity> Invoices { get; set; }= new List<InvoiceEntity>();
    }

}
