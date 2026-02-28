using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.DTO;

public partial class Order : Base.Order
{
 
    public virtual List<Base.OrderDetail> OrderDetails { get; set; } 

    public virtual List<Base.OrderTaxDetail> OrderTaxDetails { get; set; }
}
