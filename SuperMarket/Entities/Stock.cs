using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

public partial class Stock
{
    [Key]
    public Guid StockID { get; set; }

    public int Quantity { get; set; }

    [InverseProperty("Stock")]
    public virtual ICollection<StockProduct> StockProducts { get; } = new List<StockProduct>();
}
