using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Order
{
    public int OrdersId { get; set; }

    public int? Userid { get; set; }

    public DateTime? Date { get; set; }

    public double? Totalprice { get; set; }

    public byte? Status { get; set; }

    public int? Addressid { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }
}
