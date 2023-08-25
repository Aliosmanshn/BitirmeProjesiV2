using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Country
{
    public byte Id { get; set; }

    public string? Country1 { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
