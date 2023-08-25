using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Item
{
    public int ItemsId { get; set; }

    public string? Itemcode { get; set; }

    public string? Itemname { get; set; }

    public double? Unitprice { get; set; }

    public string? Category1 { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
