namespace BelayaRuswebApi.Models.ViewModels
{
    public class AddedCardVm
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Parent { get; set; }
        //public int numBilet { get; set; }
        public DateTime DateStart { get; set; }//Дата вступления
        public DateTime dateIssue { get; set; }//Дата выдАЧи билета
        public int StatusBilet { get; set; }
        public int StatusMember { get; set; }
        public string? Sex { get; set; }
        public DateTime DateBirth { get; set; }
        public int PlaceIssue { get; set; }//место вступления
        public int PlaceYchet { get; set; }
        public int Education { get; set; }
        public int SocialGroup { get; set; }
        public int SphereActivity { get; set; }
        public string? PlaceJob{ get; set; }
        public string? PostJob{ get; set; }
        public int StatusPart { get; set; }
        public string? Deputat { get; set; }
        public string RegistrationAddress { get; set; }
        public string LivingAddress { get; set; }
        public string TelephoneNumber{ get; set; }


















    }
}
