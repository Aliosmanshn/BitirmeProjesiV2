using System;
using System.Collections.Generic;

namespace BitirmeProjesiV2.Models.DB;

public partial class Comment
{
    public short Yorumid { get; set; }

    public string? CommentNameSurname { get; set; }

    public string? CommentMail { get; set; }

    public DateTime? CommentDate { get; set; }

    public bool? CommentApproval { get; set; }

    public string? CommentContents { get; set; }

    public short? TripId { get; set; }

    public virtual Trip? Trip { get; set; }
}
