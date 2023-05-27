using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class Movement
{
    public int MemberId { get; set; }

    public int WhereFromMove { get; set; }

    public int WhereToMove { get; set; }

    public virtual AccountCard Member { get; set; } = null!;

    public virtual Uzel WhereFromMoveNavigation { get; set; } = null!;

    public virtual Uzel WhereToMoveNavigation { get; set; } = null!;
}
