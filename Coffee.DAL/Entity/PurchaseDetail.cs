using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;

public partial class PurchaseDetail : Base.PurchaseDetail
{
   
    public virtual Ingredient Ingredient { get; set; } 

    public virtual Purchase Purchase { get; set; } 
}
