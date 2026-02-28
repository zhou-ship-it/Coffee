using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;
public partial class ProductLostAndDamage : Base.ProductLostAndDamage
{
   
    public virtual Menu Product { get; set; }
}
