using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;

public partial class Order : Base.Order
{
 
    public virtual List<OrderDetail> OrderDetails { get; set; } 

    public virtual List<OrderTaxDetail> OrderTaxDetails { get; set; }

    public virtual User User { get; set; }
}
