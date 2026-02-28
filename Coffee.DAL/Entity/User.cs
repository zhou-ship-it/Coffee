using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;

public partial class User : Base.User
{
    
    public virtual List<Order> Orders { get; set; }

    public virtual List<Purchase> Purchases { get; set; } 
}
