using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class PurchaseDetail
{
   
    [Column("purchaseID")]
    [StringLength(50)]
    [Unicode(false)]
    public string PurchaseId { get; set; } 


    [Column("ingredientID")]
    [StringLength(50)]
    [Unicode(false)]
    public string IngredientId { get; set; } 

    [Column("unitCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UnitCode { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("unitPrice", TypeName = "decimal(19, 4)")]
    public decimal? UnitPrice { get; set; }

}
