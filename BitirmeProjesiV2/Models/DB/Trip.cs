using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Trip
{
    public short TripId { get; set; }

    public string? TripnName { get; set; }

    public string? TripExplanation { get; set; }

    public string? TripImg { get; set; }

    /// <summary>
    /// getdate()
    /// </summary>
    public DateTime? TripDate { get; set; }

    public byte? TripScore { get; set; }

    public short? Kategoriid { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Category? Kategori { get; set; }
}
