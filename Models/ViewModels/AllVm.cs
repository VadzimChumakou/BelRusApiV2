namespace BelayaRuswebApi.Models.ViewModels
{
    public class AllVm
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string surname { get; set; }
        public string parent { get; set; }
        public int? numBilet { get; set; }//
        public string? dateStart { get; set; }//Дата вступления
        public string? dateIssue { get; set; }//Дата выдАЧи билета
        public int? statusBilet { get; set; }
        public int? statusMember { get; set; }
        public bool? sex { get; set; }
        public string? dateBirth { get; set;}
        public int? placeIssue { get; set;}//место вступления
        public int? uchetPlace { get; set; }
        public int? educarion { get; set;}
        public int? socialGroup { get; set; }
        public int? sphereActivity { get; set; }
        public string? PlaceJob { get; set; }
        public string? PostJob { get; set; }
        public int? statusPart { get; set; }
        public bool? deputat { get; set; }
        public string RegistrationAddress { get; set; }
        public string LivingAddress { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
