using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;


public partial class Order
{
    [StringLength(50)]
    [Unicode(false)]
    public string OrderId { get; set; } 


    [StringLength(50)]
    [Unicode(false)]
    public string? UserId { get; set; }

    public DateOnly? OrderDate { get; set; }

    [Column(TypeName = "decimal(19, 4)")]
    public decimal? OrderAmount { get; set; }


    [StringLength(2)]
    [Unicode(false)]
    public General.Common.OrderStatus Status { get; set; }

}
