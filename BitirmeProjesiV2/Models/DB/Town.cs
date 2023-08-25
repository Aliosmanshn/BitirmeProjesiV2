using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Town
{
    public int TownsId { get; set; }

    public short? Cityid { get; set; }

    public string? Town1 { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual City? City { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
