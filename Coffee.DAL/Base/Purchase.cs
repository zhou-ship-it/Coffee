using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;


public partial class Purchase
{
 
    [Column("purchaseID")]
    [StringLength(50)]
    [Unicode(false)]
    public string PurchaseId { get; set; } 

    [Column("supplierID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SupplierId { get; set; }

    [Column("userID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UserId { get; set; }

    [Column("purchaseDate")]
    public DateOnly? PurchaseDate { get; set; }

    [Column("amount", TypeName = "decimal(19, 4)")]
    public decimal? Amount { get; set; }

    
}
