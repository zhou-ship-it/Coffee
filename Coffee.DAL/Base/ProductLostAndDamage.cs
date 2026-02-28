using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class ProductLostAndDamage
{
   
    [Column("lossID")]
    [StringLength(50)]
    [Unicode(false)]
    public string LossId { get; set; } 

    [Column("productID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProductId { get; set; }

    [Column("reason")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Reason { get; set; }

    [Column("lossDate")]
    public DateOnly? LossDate { get; set; }

 
}
