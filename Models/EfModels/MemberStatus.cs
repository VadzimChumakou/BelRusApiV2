using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class MemberStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<AccountCard> AccountCards { get; set; } = new List<AccountCard>();
}
