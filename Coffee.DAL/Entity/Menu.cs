using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;
public partial class Menu : Base.Menu
{
   
    public virtual Category Category { get; set; }

    public virtual List<Recipe> Recipes { get; set; }
    public virtual List<OrderDetail> OrderDetails { get; set; }

    public virtual List<ProductLostAndDamage> ProductLostAndDamages { get; set; }
}
