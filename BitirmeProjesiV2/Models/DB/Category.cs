using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Category
{
    public short Kategoriid { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryImg { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
