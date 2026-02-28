using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;

public partial class Additional: Base.Additional
{

    public virtual Ingredient Ingredient { get; set; }
    public virtual OrderDetail OrderDetail { get; set; }
}
