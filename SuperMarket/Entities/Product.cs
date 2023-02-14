using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

[Index("CategoryID", Name = "IX_Products_CategoryID")]
public partial class Product
{
    [Key]
    public Guid ProductID { get; set; }

    [StringLength(50)]
    public string ProductName { get; set; } = null!;

    public Guid CategoryID { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [ForeignKey("CategoryID")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<ProductInvoiceLineEntity> ProductInvoiceLineEntities { get; } = new List<ProductInvoiceLineEntity>();

    [InverseProperty("Product")]
    public virtual ICollection<StockProduct> StockProducts { get; } = new List<StockProduct>();
}
