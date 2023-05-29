namespace BelayaRuswebApi.Models.ViewModels
{
    public class SearchVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int PartyСardNumber { get; set; }
        public int PatryCardStatusId { get; set; }
        public int PartyEntryPlaceId { get; set; }
        public int RegistrationPlaceId { get; set; }
        public DateTime Birdhday { get; set; }
        public DateTime DateStart { get; set; }

        public int EducationId { get; set; }
        public int SocialCategoryId { get; set; }
        public int ActivitySphereId { get; set; }
        public int MembershipStatusId { get; set; }
        public int PartyPositionId { get; set; }
        public bool Sex { get; set; }
        public bool WasDeputi { get; set; }

    }
}
