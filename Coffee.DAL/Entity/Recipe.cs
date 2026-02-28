using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;


public partial class Recipe : Base.Recipe
{
    public virtual Menu Product { get; set; }
    public virtual Ingredient Ingredient { get; set; } 
}
