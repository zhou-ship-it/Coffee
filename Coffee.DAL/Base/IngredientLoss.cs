using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;


public partial class IngredientLoss
{
    [StringLength(50)]
    [Unicode(false)]
    public string IngredientLossId { get; set; } 

    [StringLength(50)]
    [Unicode(false)]
    public string? IngredientId { get; set; }


    public int? QuantityLost { get; set; }

    [Column("reason")]
    [StringLength(450)]
    [Unicode(false)]
    public string? Reason { get; set; }

    [Column("lossDate")]
    public DateOnly? LossDate { get; set; }

}
