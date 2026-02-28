using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;
public partial class Category
{
    
    [StringLength(50)]
    [Unicode(false)]
    public string CategoryId { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? CategoryName { get; set; }

}
