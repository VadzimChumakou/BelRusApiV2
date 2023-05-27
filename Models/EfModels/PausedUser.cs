using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class PausedUser
{
    public int MemberId { get; set; }

    public DateTime PauseDate { get; set; }

    public virtual AccountCard Member { get; set; } = null!;
}
