using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Entities
{
    //public class PayEntity
    //{
    //    // primary key
    //    [Key]
    //    public Guid PayID { get; set; }
    //    // amount paid
    //    [Required]
    //    [Column(TypeName = "decimal(18,2)")]
    //    public decimal Amount { get; set; }
    //    // date of payment
    //    [Required]
    //    public DateTime PayDate { get; set; }
    //    // foreign key to the Invoice table
    //    [Required]
    //    public Guid InvoiceID { get; set; }
    //    // navigation property to the Invoice table
    //    [ForeignKey("InvoiceID")]     
    //    public InvoiceEntity Invoice { get; set; }


    //}
    //public class PayEntity
    //{
    //    [Key]
    //    public Guid PayID { get; set; }

    //    [Required]
    //    public DateTime PayDate { get; set; }

    //    [Required]
    //    public decimal Amount { get; set; }

    //    public Guid InvoiceID { get; set; }
    //    [ForeignKey("InvoiceID")]
    //    public InvoiceEntity Invoice { get; set; }
    //}

    //public class PayEntity
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public Guid PayID { get; set; }

    //    [Required]
    //    public DateTime PayDate { get; set; }

    //    [Required]
    //    public decimal Amount { get; set; }

    //    public Guid InvoiceID { get; set; }

    //    [ForeignKey("InvoiceID")]

    //    public InvoiceEntity Invoice { get; set; }
    //}
    //public class PayEntity
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public Guid PayID { get; set; }

    //    [Required]
    //    public DateTime PayDate { get; set; }

    //    [Required]
    //    [Column(TypeName = "decimal(18,2)")]
    //    public decimal Amount { get; set; }

    //    public ICollection<InvoiceEntity> Invoices { get; set; }
    //}

    public class PayEntity
    {
        public Guid PayID { get; set; }
        public DateTime PayDate { get; set; }
        public decimal Amount { get; set; }
    }

}
