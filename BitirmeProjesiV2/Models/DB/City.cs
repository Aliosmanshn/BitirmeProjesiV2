using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class City
{
    public short Id { get; set; }

    public byte? Countryid { get; set; }

    public string? City1 { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<Town> Towns { get; set; } = new List<Town>();
}
