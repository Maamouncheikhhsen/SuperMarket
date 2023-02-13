using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{  
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required]
        public Guid ProductID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public Guid CategoryID { get; set; }

        [ForeignKey (nameof(CategoryID))]
        public CategoryEntity Category { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual ICollection<StockProductEntity> StockProducts { get; set; }

        public virtual  ICollection<ProductInvoiceLineEntity> ProductInvoiceLineEntities { get; set; }

    }
}
