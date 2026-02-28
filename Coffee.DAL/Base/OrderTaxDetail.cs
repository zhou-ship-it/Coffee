using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class OrderTaxDetail
{
  
    [Column("orderID")]
    [StringLength(50)]
    [Unicode(false)]
    public string OrderId { get; set; } 

    [Column("taxID")]
    [StringLength(50)]
    [Unicode(false)]
    public string TaxId { get; set; } 

    [Column("description")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("amount", TypeName = "decimal(19, 4)")]
    public decimal? Amount { get; set; }

}
