using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class Education
{
    public int Id { get; set; }

    public string Grade { get; set; } = null!;

    public virtual ICollection<AccountCard> AccountCards { get; set; } = new List<AccountCard>();
}
