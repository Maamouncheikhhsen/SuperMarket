using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class StockEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StockID { get; set; }
        [Required]
        public int Quantity { get; set; }
            
        public virtual ICollection<StockProductEntity> StockProducts { get; set; }
    }
}
