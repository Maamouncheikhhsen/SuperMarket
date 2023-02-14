using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

[Index("CustomerID", Name = "IX_Invoices_CustomerID")]
[Index("PayID", Name = "IX_Invoices_PayID", IsUnique = true)]
public partial class Invoice
{
    [Key]
    public Guid InvoiceID { get; set; }

    public DateTime InvoiceDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    public Guid CustomerID { get; set; }

    public Guid PayID { get; set; }

    [ForeignKey("CustomerID")]
    [InverseProperty("Invoices")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Invoice")]
    public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();

    [ForeignKey("PayID")]
    [InverseProperty("Invoice")]
    public virtual Pay Pay { get; set; } = null!;
}
