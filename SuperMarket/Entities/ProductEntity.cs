using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Entities
{
    //public class ProductEntity
    //{//primary key
    //    [Key]
    //    public Guid ProductID { get; set; }
    //    [Required]
    //    [MaxLength(50)]
    //    public string ProductName { get; set; }

    //    // foreign key to the Category table   
    //    [Required]
    //    public Guid CategoryID { get; set; }

    //    // navigation property to the Category table  
    //    [ForeignKey("CategoryID")]
    //    public CategoryEntity Category { get; set; }

    //    // product price 
    //    [Required]
    //    [Column(TypeName = "decimal(18,2)")]
    //    public decimal Price { get; set; }

    //    // navigation property to the InvoiceLine  
    //    public ICollection<InvoiceLineEntity> InvoiceLines { get; set; }

    //}

    public class ProductEntity
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryID { get; set; }
        public decimal Price { get; set; }

    }
}
