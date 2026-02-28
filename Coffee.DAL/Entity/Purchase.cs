using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Entity;


public partial class Purchase : Base.Purchase
{
   
    public virtual List<PurchaseDetail> PurchaseDetails { get; set; } 

   
    public virtual Supplier Supplier { get; set; }

  
    public virtual List<SupplierPayment> SupplierPayments { get; set; }

    public virtual User? User { get; set; }
}
