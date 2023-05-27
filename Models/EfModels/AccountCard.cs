using System;
using System.Collections.Generic;

namespace BelRusApiV2.Models.EfModels;

public partial class AccountCard
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int PartyСardNumber { get; set; }

    public DateTime IssueDatePartyCard { get; set; }

    public int PartyCardStatusId { get; set; }

    public bool Sex { get; set; }

    public DateTime Birhday { get; set; }

    public DateTime PartyEntryDate { get; set; }

    public int PartyEntryPlaceId { get; set; }

    public int MembershipStatusId { get; set; }

    public int RegistrationPlaceId { get; set; }

    public int EducationId { get; set; }

    public int SocialCategoryId { get; set; }

    public int ActivitySphereId { get; set; }

    public int PartyPositionId { get; set; }

    public bool WasDeputi { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public DateTime LastLoginDate { get; set; }

    public string? Note { get; set; }

    public string? PhotoPath { get; set; }

    public virtual ActivitySphere ActivitySphere { get; set; } = null!;

    public virtual Authorizatio? Authorizatio { get; set; }

    public virtual ChleniUzla? ChleniUzla { get; set; }

    public virtual ContactInformation? ContactInformation { get; set; }

    public virtual Education Education { get; set; } = null!;

    public virtual Job? Job { get; set; }

    public virtual JournalAudit? JournalAudit { get; set; }

    public virtual KickedMember? KickedMember { get; set; }

    public virtual MemberStatus MembershipStatus { get; set; } = null!;

    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();

    public virtual PartyCardStatus PartyCardStatus { get; set; } = null!;

    public virtual PartyPosition PartyPosition { get; set; } = null!;

    public virtual PausedUser? PausedUser { get; set; }

    public virtual SocialCategory SocialCategory { get; set; } = null!;
}
