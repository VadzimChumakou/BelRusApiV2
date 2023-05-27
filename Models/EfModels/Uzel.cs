using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class Uzel
{
    public int Id { get; set; }

    public string Nazva { get; set; } = null!;

    public int VetkaId { get; set; }

    public virtual ICollection<ChleniUzla> ChleniUzlas { get; set; } = new List<ChleniUzla>();

    public virtual ICollection<Movement> MovementWhereFromMoveNavigations { get; set; } = new List<Movement>();

    public virtual ICollection<Movement> MovementWhereToMoveNavigations { get; set; } = new List<Movement>();

    public virtual Vetka Vetka { get; set; } = null!;
}
