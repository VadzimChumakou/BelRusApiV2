using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class Role
{
    public int Id { get; set; }

    public string Role1 { get; set; } = null!;

    public virtual ICollection<Authorizatio> Authorizatios { get; set; } = new List<Authorizatio>();
}
