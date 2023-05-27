using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class Vetka
{
    public int Id { get; set; }

    public string Nazva { get; set; } = null!;

    public virtual ICollection<Uzel> Uzels { get; set; } = new List<Uzel>();
}
