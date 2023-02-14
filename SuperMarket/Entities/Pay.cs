using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Entities;

public partial class Pay
{
    [Key]
    public Guid PayID { get; set; }

    public DateTime PayDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [InverseProperty("Pay")]
    public virtual Invoice? Invoice { get; set; }
}
