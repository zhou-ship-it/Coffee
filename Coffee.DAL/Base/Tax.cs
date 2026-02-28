using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class Tax
{

    [Column("taxID")]
    [StringLength(50)]
    [Unicode(false)]
    public string TaxId { get; set; } 

    [Column("taxName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TaxName { get; set; }

    [Column("charge", TypeName = "decimal(19, 4)")]
    public decimal? Charge { get; set; }

}
