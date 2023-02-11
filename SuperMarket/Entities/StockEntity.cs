using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class StockEntity
    {
        public Guid StockID { get; set; }
        public int Quantity { get; set; }
        public Guid ProductID { get; set; }
    }
}
