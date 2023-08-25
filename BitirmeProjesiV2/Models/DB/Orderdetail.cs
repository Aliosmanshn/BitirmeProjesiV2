using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Orderdetail
{
    public int OrderDetailsId { get; set; }

    public int? Orderid { get; set; }

    public int? Itemid { get; set; }

    public int? Amount { get; set; }

    public double? Unitprice { get; set; }

    public double? Linetotal { get; set; }

    public virtual Item? Item { get; set; }

    public virtual Order? Order { get; set; }
}
