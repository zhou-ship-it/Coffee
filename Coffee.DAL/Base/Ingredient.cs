using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class Ingredient
{
    [StringLength(50)]
    [Unicode(false)]
    public string IngredientId { get; set; } 

    [StringLength(50)]
    [Unicode(false)]
    public string? IngredientName { get; set; }

    public int? StockQuantity { get; set; }

    public int? ReorderLevel { get; set; }

    [Column("unitCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UnitCode { get; set; }

    [Column("rate")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Rate { get; set; }

  
}
