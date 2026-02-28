using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;


public partial class Supplier
{
   
    [Column("supplierID")]
    [StringLength(50)]
    [Unicode(false)]
    public string SupplierId { get; set; } 

    [Column("supplierName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SupplierName { get; set; }

    [Column("phoneNumber")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

}
