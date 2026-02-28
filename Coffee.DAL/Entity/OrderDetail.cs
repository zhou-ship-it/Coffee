using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;

public partial class OrderDetail : Base.OrderDetail
{
   
    public virtual Order Order { get; set; }

    public virtual List<Additional> Additionals { get; set; }
    public virtual Menu Product { get; set; } 
}
