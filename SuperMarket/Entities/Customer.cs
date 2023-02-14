using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

public partial class Customer
{
    [Key]
    public Guid CustomerID { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Mail { get; set; } = null!;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
