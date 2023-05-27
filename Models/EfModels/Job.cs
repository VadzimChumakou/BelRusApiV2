using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class Job
{
    public int MemberId { get; set; }

    public string Place { get; set; } = null!;

    public string Post { get; set; } = null!;

    public virtual AccountCard Member { get; set; } = null!;
}
