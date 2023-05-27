using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class Authorizatio
{
    public int MemberId { get; set; }

    public string Password { get; set; } = null!;

    public string Login { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual AccountCard Member { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
