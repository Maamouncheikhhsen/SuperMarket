using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

[Index("ProductID", Name = "IX_StockProducts_ProductID")]
[Index("StockID", Name = "IX_StockProducts_StockID")]
public partial class StockProduct
{
    [Key]
    public Guid StockProductID { get; set; }

    public Guid StockID { get; set; }

    public Guid ProductID { get; set; }

    [ForeignKey("ProductID")]
    [InverseProperty("StockProducts")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("StockID")]
    [InverseProperty("StockProducts")]
    public virtual Stock Stock { get; set; } = null!;
}
