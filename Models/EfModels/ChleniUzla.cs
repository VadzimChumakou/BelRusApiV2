using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class ChleniUzla
{
    public int UzelId { get; set; }

    public int MemberId { get; set; }

    public int Role { get; set; }

    public virtual AccountCard Member { get; set; } = null!;

    public virtual Uzel Uzel { get; set; } = null!;
}
