using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    public class CategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public virtual ICollection<ProductEntity>? Products { get; set; }= new List<ProductEntity>();
    }
}
