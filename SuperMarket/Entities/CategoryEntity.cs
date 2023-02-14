using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class CategoryEntity
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
