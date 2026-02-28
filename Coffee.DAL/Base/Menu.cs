using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;


public partial class Menu
{
  
    [Column("productID")]
    [StringLength(50)]
    [Unicode(false)]
    public string ProductId { get; set; } 

    [Column("categoryID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CategoryId { get; set; }

    [Column("productName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    [Column("productImage")]
    [StringLength(450)]
    [Unicode(false)]
    public string? ProductImage { get; set; }

    [Column("price", TypeName = "decimal(19, 4)")]
    public decimal? Price { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

}
