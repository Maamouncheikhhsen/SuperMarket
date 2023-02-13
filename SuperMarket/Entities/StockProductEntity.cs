using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SuperMarket.Entities
{
    public class StockProductEntity
    {
        [Key]
        public Guid StockProductID { get; set; }
        public Guid StockID { get; set; }

        [ForeignKey(nameof(StockID))]
        public StockEntity Stock { get; set; }
        
        public Guid ProductID { get; set; }

        [ForeignKey("ProductID")]
        public ProductEntity Product { get; set; }
    }
}
