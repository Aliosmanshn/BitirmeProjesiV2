using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Invoice
{
    public int Id { get; set; }

    public int? Orderid { get; set; }

    public DateTime? Date { get; set; }

    public int? Addressid { get; set; }

    public string? Cargoficheno { get; set; }

    public double? Totalprice { get; set; }

    public virtual ICollection<Invoicedetail> Invoicedetails { get; set; } = new List<Invoicedetail>();

    public virtual Order? Order { get; set; }
}
