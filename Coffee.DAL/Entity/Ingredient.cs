using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;
public partial class Ingredient : Base.Ingredient
{
    
    public virtual List<Additional> Additionals { get; set; }
    public virtual List<IngredientLoss> IngredientLosses { get; set; }
    public virtual List<PurchaseDetail> PurchaseDetails { get; set; }
    public virtual List<Recipe> Recipes { get; set; }
}
