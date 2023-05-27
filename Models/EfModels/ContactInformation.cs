using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class ContactInformation
{
    public int MemberId { get; set; }

    public string RegistrationAddress { get; set; } = null!;

    public string LivingAddress { get; set; } = null!;

    public string TelephoneNumber { get; set; } = null!;

    public virtual AccountCard Member { get; set; } = null!;
}
