using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class District
{
    public int Id { get; set; }

    public int? Townid { get; set; }

    public string? District1 { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Town? Town { get; set; }
}
