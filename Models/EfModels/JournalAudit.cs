using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class JournalAudit
{
    public int MemberId { get; set; }

    public string Data { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string Target { get; set; } = null!;

    public virtual AccountCard Member { get; set; } = null!;
}
