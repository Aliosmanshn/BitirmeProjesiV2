using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Address
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public byte? Countryid { get; set; }

    public short? Cityid { get; set; }

    public int? Townid { get; set; }

    public int? Districtid { get; set; }

    public string? Postalcode { get; set; }

    public string? Addresstext { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual District? District { get; set; }

    public virtual Town? Town { get; set; }

    public virtual User? User { get; set; }
}
