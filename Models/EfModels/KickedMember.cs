using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class KickedMember
{
    public int MemberId { get; set; }

    public DateTime KickDate { get; set; }

    public virtual AccountCard Member { get; set; } = null!;
}
