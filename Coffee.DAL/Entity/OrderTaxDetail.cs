using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;


public partial class OrderTaxDetail : Base.OrderTaxDetail
{
    public virtual Order Order { get; set; } 

    public virtual Tax Tax { get; set; } 
}
