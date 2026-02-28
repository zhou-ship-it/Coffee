using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Coffee.DAL.Base;

public partial class SupplierPayment
{

    [Column("supplierPaymentID")]
    [StringLength(50)]
    [Unicode(false)]
    public string SupplierPaymentId { get; set; }

    [Column("purchaseID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PurchaseId { get; set; }

    [Column("paymentDate")]
    public DateOnly? PaymentDate { get; set; }

    [Column("paymentMethod")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentMethod { get; set; }

    [Column(TypeName = "decimal(19, 4)")]
    public decimal? AmountPaid { get; set; }

}
