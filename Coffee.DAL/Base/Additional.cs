using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class Additional
{
    [StringLength(50)]
    [Unicode(false)]
    public string OrderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ProductId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string IngredientId { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "decimal(19, 4)")]
    public decimal? Price { get; set; }

}
