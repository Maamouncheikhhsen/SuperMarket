using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

[Index("InvoiceID", Name = "IX_InvoiceLines_InvoiceID")]
public partial class InvoiceLine
{
    [Key]
    public Guid InvoiceLineID { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    public Guid InvoiceID { get; set; }

    [ForeignKey("InvoiceID")]
    [InverseProperty("InvoiceLines")]
    public virtual Invoice Invoice { get; set; } = null!;

    [InverseProperty("InvoiceLine")]
    public virtual ICollection<ProductInvoiceLineEntity> ProductInvoiceLineEntities { get; } = new List<ProductInvoiceLineEntity>();
}
