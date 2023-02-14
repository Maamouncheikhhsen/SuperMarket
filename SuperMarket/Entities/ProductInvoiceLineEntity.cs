using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

[Table("ProductInvoiceLineEntity")]
[Index("InvoiceLineID", Name = "IX_ProductInvoiceLineEntity_InvoiceLineID")]
[Index("ProductID", Name = "IX_ProductInvoiceLineEntity_ProductID")]
public partial class ProductInvoiceLineEntity
{
    [Key]
    public Guid ProductInvoiceLineID { get; set; }

    public Guid ProductID { get; set; }

    public Guid InvoiceLineID { get; set; }

    [ForeignKey("InvoiceLineID")]
    [InverseProperty("ProductInvoiceLineEntities")]
    public virtual InvoiceLine InvoiceLine { get; set; } = null!;

    [ForeignKey("ProductID")]
    [InverseProperty("ProductInvoiceLineEntities")]
    public virtual Product Product { get; set; } = null!;
}
