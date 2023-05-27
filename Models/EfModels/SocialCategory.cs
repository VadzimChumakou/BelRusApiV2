using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class SocialCategory
{
    public int Id { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<AccountCard> AccountCards { get; set; } = new List<AccountCard>();
}
