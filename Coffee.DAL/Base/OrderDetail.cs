using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;


public partial class OrderDetail
{
  
    [Column("orderID")]
    [StringLength(50)]
    [Unicode(false)]
    public string OrderId { get; set; }

  
    [Column("productID")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductId { get; set; } 

    [Column("unitPrice", TypeName = "decimal(19, 4)")]
    public decimal? UnitPrice { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("notes")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Notes { get; set; }

}
