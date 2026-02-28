using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.DTO;

public partial class OrderDetail : Base.OrderDetail
{
   
  
    public virtual List<Base.Additional> Additionals { get; set; }
    
}
