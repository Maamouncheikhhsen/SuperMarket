using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class StockProductEntity
    {
        public Guid StockID { get; set; }

        public StockEntity Stock { get; set; }

        public Guid ProductID { get; set; }

        public ProductEntity Product { get; set; }
    }
}
