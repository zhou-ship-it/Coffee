using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;


public partial class Recipe
{
    
    [Column("productID")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductId { get; set; } 

   
    [Column("ingredientID")]
    [StringLength(50)]
    [Unicode(false)]
    public string IngredientId { get; set; } 

    [Column("quantityRequired")]
    public int? QuantityRequired { get; set; }

}
