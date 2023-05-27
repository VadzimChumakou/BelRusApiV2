using BelayaRuswebApi.Models.ViewModels;
using BelRusApiV2.Models.EfModels;
using BelRusApiV2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Models.ViewModels;

namespace BelayaRuswebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPageController : ControllerBase
    {

        [HttpPost]
        [Route("Search")]
        public IActionResult SearchUser(SearchVm card)
        {
            List<AccountCard> a = new List<AccountCard>();
            using (BelayaRusV5Context db = new BelayaRusV5Context()){a = db.AccountCards.ToList();}
            List<AccountCard> filtered = a;
            if (!string.IsNullOrEmpty(card.Name)) filtered = filtered.Where(x => x.Name == card.Name).ToList();
            if (!string.IsNullOrEmpty(card.Surname)) filtered = filtered.Where(x => x.Surname == card.Surname).ToList();
            if (!string.IsNullOrEmpty(card.Patronymic)) filtered = filtered.Where(x => x.Patronymic == card.Patronymic).ToList();
            if (card.Party—ardNumber != 0) filtered = filtered.Where(x => x.Party—ardNumber == card.Party—ardNumber).ToList();
            if (card.PartyEntryPlaceId != 0) filtered = filtered.Where(x => x.PartyEntryPlaceId == card.PartyEntryPlaceId).ToList();
            if (card.PatryCardStatusId != 0) filtered = filtered.Where(x => x.PartyCardStatusId == card.PatryCardStatusId).ToList();
            if (card.RegistrationPlaceId != 0) filtered = filtered.Where(x => x.RegistrationPlaceId == card.RegistrationPlaceId).ToList();
            if (card.EducationId != 0) filtered = filtered.Where(x => x.EducationId == card.EducationId).ToList();
            if (card.SocialCategoryId != 0) filtered = filtered.Where(x => x.SocialCategoryId == card.SocialCategoryId).ToList();
            if (card.ActivitySphereId != 0) filtered = filtered.Where(x => x.ActivitySphereId == card.ActivitySphereId).ToList();
            if (card.MembershipStatusId != 0) filtered = filtered.Where(x => x.MembershipStatusId == card.MembershipStatusId).ToList();
            if (card.PartyPositionId != 0) filtered = filtered.Where(x => x.PartyPositionId == card.PartyPositionId).ToList();
            if (card.WasDeputi != null) filtered = filtered.Where(x => x.WasDeputi == card.WasDeputi).ToList();
            if (card.Sex != null) filtered = filtered.Where(x => x.Sex == card.Sex).ToList();
            return Ok(filtered);
        }
        [HttpGet]
        [Route("GetOptions")]
        public IActionResult GetOptions()
        {
            var uzli = new List<Uzel>();
            var vetki = new List<Vetka>();
            var socCatgrs = new List<SocialCategory>();
            var actSpheres = new List<ActivitySphere>();
            var educats = new List<Education>();
            var cardStts = new List<PartyCardStatus>();
            var mbrStts = new List<MemberStatus>();
            var prtPoss = new List<PartyPosition>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                uzli = db.Uzels.ToList();
                vetki = db.Vetkas.ToList();
                socCatgrs = db.SocialCategories.ToList();
                actSpheres = db.ActivitySpheres.ToList();
                educats = db.Educations.ToList();
                cardStts = db.PartyCardStatuses.ToList();
                mbrStts = db.MemberStatuses.ToList();
                prtPoss = db.PartyPositions.ToList();
            }

            List<edu> e = new List<edu>();
            List<crdSt> cs = new List<crdSt>();
            List<soc> s = new List<soc>();
            List<partPos> p = new List<partPos>();
            List<mbrSt> ms = new List<mbrSt>();
            List<act> a = new List<act>();
            List<regPlc> r = new List<regPlc>();
            List<entrPlc> ep = new List<entrPlc>();

            foreach (var item in vetki){ep.Add(new entrPlc{id = item.Id,val = item.Nazva});}
            foreach (var item in uzli){r.Add(new regPlc{id = item.Id,val = item.Nazva});}
            foreach (var item in actSpheres){a.Add(new act{id = item.Id,val = item.Sphere});}
            foreach (var item in educats){e.Add(new edu{id = item.Id,val = item.Grade});}
            foreach (var item in cardStts){cs.Add(new crdSt{id = item.Id,val = item.Status});}
            foreach (var item in socCatgrs){s.Add(new soc{id = item.Id,val = item.Category});}
            foreach (var item in mbrStts){ms.Add(new mbrSt{id = item.StatusId,val = item.Status});}
            foreach (var item in prtPoss){p.Add(new partPos{id = item.Id,val = item.Position});}
            OptionsVm res = new OptionsVm{acts = a,socs = s,crdSt = cs,entrPlcs = ep,regPlcs = r,mbrSt = ms,partPoss = p,edus = e};
            return Ok(res);
        }

        
        [HttpPost]
        [Route("addCard")]
        public IActionResult AddCard(AddedCardVm inf)
        {
            bool pol;
            if (inf.Sex == "ÃÛÊÒÍÓÈ") { pol = true; } else { pol = false; }
            bool dep;
            if (inf.Deputat == "ƒ‡") { dep = true; } else { dep = false; }
            Job newJob = new Job
            {
                Place = inf.PlaceJob,
                Post = inf.PostJob,
            };
            ContactInformation newContactInfo = new ContactInformation
            {
                LivingAddress = inf.LivingAddress,
                RegistrationAddress = inf.RegistrationAddress,
                TelephoneNumber = inf.TelephoneNumber,
            };
            AccountCard newCard = new AccountCard
            {
                //Id = inf.id,
                Name = inf.Name,
                Surname = inf.Surname,
                Patronymic = inf.Parent,
                Party—ardNumber = 3003,
                IssueDatePartyCard = inf.dateIssue,
                PartyCardStatusId = inf.StatusBilet,
                Sex = pol,
                Birhday = inf.DateBirth,
                PartyEntryDate = inf.DateStart,
                PartyEntryPlaceId = inf.PlaceIssue,
                MembershipStatusId = inf.StatusMember,
                RegistrationPlaceId = inf.PlaceYchet,
                EducationId = inf.Education,
                SocialCategoryId = inf.SocialGroup,
                ActivitySphereId = inf.SphereActivity,
                PartyPositionId = inf.StatusPart,
                WasDeputi = dep,
                Job = newJob,
                ContactInformation = newContactInfo,
                LastUpdateDate = DateTime.Today
            };
            //2 paus 3 stop

            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                int numCrd = db.AccountCards.Max(p => p.Party—ardNumber) + 1;
                if (newCard.MembershipStatusId == 2)
                {
                    PausedUser paused = new PausedUser
                    {
                        Member = newCard,
                        PauseDate = DateTime.Today
                    };
                    db.PausedUsers.Add(paused);
                }
                if (newCard.MembershipStatusId == 3)
                {
                    KickedMember kicked = new KickedMember
                    {
                        Member = newCard,
                        KickDate = DateTime.Today
                    };
                    db.KickedMembers.Add(kicked);
                }
                newCard.Party—ardNumber = numCrd; 
                db.AccountCards.Add(newCard);
                db.SaveChanges();
            }

            return Ok();
        }
        [HttpGet]
        [Route("tablePOO")]
        public IActionResult POO()
        {
            List<tablePOO> res = new List<tablePOO>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var users = db.AccountCards;
                var uzels = db.Uzels.ToList();
                foreach (var u in users)
                {
                    tablePOO cardVm = new tablePOO
                    {
                        id = u.Id,
                        name = u.Name,
                        surname = u.Surname,
                        parent = u.Patronymic,
                        numBilet = u.Party—ardNumber,
                        dateStart = u.PartyEntryDate.ToShortDateString(),
                        place = uzels.FirstOrDefault(uz => uz.Id == u.PartyEntryPlaceId).Nazva
                    };
                    res.Add(cardVm);
                }
            }
            return Ok(res);
        }
        [HttpGet]
        [Route("tableNO")]
        public IActionResult NO()
        {
            List<tableNO> res = new List<tableNO>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var pausedUsers = db.KickedMembers;
                var users = db.AccountCards.ToList();
                foreach (var u in pausedUsers)
                {
                    tableNO cardVm = new tableNO
                    {
                        id = u.MemberId,
                        name = users.FirstOrDefault(us => us.Id == u.MemberId).Name,
                        surname = users.FirstOrDefault(us => us.Id == u.MemberId).Surname,
                        parent = users.FirstOrDefault(us => us.Id == u.MemberId).Patronymic,
                        dateFinish = u.KickDate.ToShortDateString()
                    };
                    res.Add(cardVm);
                }
            }
            return Ok(res);
        }
        [HttpGet]
        [Route("tablePause")]
        public IActionResult paused()
        {
            List<tablePause> res = new List<tablePause>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var pausedUsers = db.PausedUsers;
                var users = db.AccountCards.ToList();
                foreach (var u in pausedUsers)
                {
                    tablePause cardVm = new tablePause
                    {
                        id = u.MemberId,
                        name = users.FirstOrDefault(us => us.Id == u.MemberId).Name,
                        surname = users.FirstOrDefault(us => us.Id == u.MemberId).Surname,
                        parent = users.FirstOrDefault(us => us.Id == u.MemberId).Patronymic,
                        numBilet = users.FirstOrDefault(us => us.Id == u.MemberId).Party—ardNumber,
                        dateStart = users.FirstOrDefault(us => us.Id == u.MemberId).PartyEntryDate.ToShortDateString(),
                        datePause = u.PauseDate.ToShortDateString()
                    };
                    res.Add(cardVm);
                }
            }
            return Ok(res);
        }
        
        [HttpGet]
        [Route("GetOne")]
        public IActionResult Action(int id)
        {
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var u = db.AccountCards.FirstOrDefault(u => u.Id == id);
                var j = db.Jobs.First(u => u.MemberId == id);
                var c = db.ContactInformations.First(u => u.MemberId == id);
                AllVm card = new AllVm
                {
                    id = u.Id,
                    surname = u.Surname,
                    name = u.Name,
                    parent =u.Patronymic,
                    numBilet = u.Party—ardNumber,
                    dateStart = u.PartyEntryDate.ToShortDateString(),
                    dateIssue = u.IssueDatePartyCard.ToShortDateString(),
                    statusBilet = u.PartyCardStatusId,
                    statusMember = u.MembershipStatusId,
                    sex = u.Sex,
                    dateBirth = u.Birhday.ToShortDateString(),
                    placeIssue = u.PartyEntryPlaceId,
                    educarion = u.EducationId,
                    socialGroup = u.SocialCategoryId,
                    sphereActivity = u.ActivitySphereId,
                    
                    statusPart = u.PartyPositionId,
                    deputat = u.WasDeputi,

                    uchetPlace = u.RegistrationPlaceId
                };
                if(c != null)
                {
                    card.LivingAddress = c.LivingAddress;
                    card.RegistrationAddress =c.RegistrationAddress;
                    card.TelephoneNumber = c.TelephoneNumber;
                }
                else
                {
                    card.LivingAddress = "ÕÂ ÛÍ‡Á‡Ì‡";
                    card.RegistrationAddress = "ÕÂ ÛÍ‡Á‡Ì‡";
                    card.TelephoneNumber = "ÕÂ ÛÍ‡Á‡Ì‡";
                }
                if (j != null)
                {
                    card.PlaceJob = j.Place;
                    card.PostJob =  j.Post;
                }
                else {
                    card.PlaceJob = "ŒÚÒÛÚÒÚ‚ÛÂÚ";
                    card.PostJob = "ŒÚÒÛÚÒÚ‚ÛÂÚ";
                }
                return Ok(card);
            }
        }
        //getAll
        /*
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Action()
        {
            List<AllVm> res = new List<AllVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var users = db.AccountCards.Include(u => u.Job).Include(u => u.PartyCardStatus).Include(u => u.MembershipStatus).Include(u => u.Education).Include(u => u.SocialCategory).Include(u => u.ActivitySphere).Include(u => u.PartyPosition).Include(u => u.Job);
                var uzels = db.Uzels.Include(uz => uz.ChleniUzlas).ToList();
                var partyPosition = db.PartyPositions.ToList();
                var socialCategory = db.SocialCategories.ToList();
                var jobes = db.Jobs.ToList();
                var contactInfo = db.ContactInformations.ToList();
                var activitySphere = db.ActivitySpheres.ToList();
                var vetkas = db.Vetkas.ToList();
                string ret;
                string ret2;
                foreach (var u in users)
                {
                    var jobsa = jobes.FirstOrDefault(v => v.MemberId == u.Id);
                    var contacta = contactInfo.FirstOrDefault(v => v.MemberId == u.Id);
                    if (jobsa == null) { ret = "nooone"; } else { ret = jobsa.Place + " , " + jobsa.Post; }
                    if (contacta == null) { ret2 = "nooone"; } else { ret2 = contacta.LivingAddress + " , " + contacta.RegistrationAddress + " , " + contacta.TelephoneNumber; }
                    AllVm card = new AllVm
                    {

                        id = u.Id,
                        surname = u.Surname,
                        name = u.Name,
                        parent = u.Patronymic,
                        numBilet = u.Party—ardNumber,
                        dateStart = u.PartyEntryDate.ToShortDateString(),
                        dateIssue = u.IssueDatePartyCard.ToShortDateString(),
                        statusBilet = u.PartyCardStatus.Status,//partycardStatus.FirstOrDefault(cs => cs.Id == u.PartyCardStatusId).Status,
                        statusMember = u.MembershipStatus.Status,//memberStatus.FirstOrDefault(ms => ms.StatusId == u.MembershipStatusId).Status,
                        sex = (u.Sex) ? "MÛÊÒÍÓÈ" : "∆ÂÌÒÍËÈ",
                        dateBirth = u.Birhday.ToShortDateString(),
                        placeIssue = uzels.FirstOrDefault(uz => uz.Id == u.PartyEntryPlaceId).Nazva,
                        educarion = u.Education.Grade,//education.FirstOrDefault(v => v.Id == u.EducationId).Grade,
                        socialGroup = u.SocialCategory.Category,//socialCategory.FirstOrDefault(v => v.Id == u.SocialCategoryId).Category,
                        sphereActivity = u.ActivitySphere.Sphere, //activitySphere.FirstOrDefault(v => v.Id == u.ActivitySphereId).Sphere,
                        Jobas = ret,
                        statusPart = u.PartyPosition.Position,//partyPosition.FirstOrDefault(cs => cs.Id == u.PartyPositionId).Position,
                        deputat = (u.WasDeputi) ? "ƒ‡" : "ÕÂÚ",
                        contact = ret2,
                        uchetPlace = vetkas.FirstOrDefault(v => v.Id == u.RegistrationPlaceId).Nazva
                    };
                    res.Add(card);
                }
            }
            return Ok(res);
        }*/
        //ŒÔ¯ÌÒ˚ ÔÓ ÓÚ‰ÂÎ¸ÌÓÒÚË
        /*
        [HttpGet]
        [Route("GetUzl")]
        public IActionResult GetUzl()
        {

            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.Uzels.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.Id, val = item.Nazva });
                }
            }
            return Ok(a);
        }
        [HttpGet]
        [Route("GetVtk")]
        public IActionResult GetVtk()
        {
            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.Vetkas.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.Id, val = item.Nazva });
                }
            }
            return Ok(a);
        }
        [HttpGet]
        [Route("GetSocCat")]
        public IActionResult GetSocCat()
        {
            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.SocialCategories.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.Id, val = item.Category });
                }
            }
            return Ok(a);
        }
        [HttpGet]
        [Route("GetActSphr")]
        public IActionResult GetActSphr()
        {
            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.ActivitySpheres.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.Id, val = item.Sphere });
                }
            }
            return Ok(a);
        }
        [HttpGet]
        [Route("GetEdu")]
        public IActionResult GetEdu()
        {
            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.Educations.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.Id, val = item.Grade });
                }
            }
            return Ok(a);
        }
        [HttpGet]
        [Route("GetPrtPs")]
        public IActionResult GetActPrtPs()
        {
            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.PartyPositions.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.Id, val = item.Position });
                }
            }
            return Ok(a);
        }
        [HttpGet]
        [Route("GetMbrSts")]
        public IActionResult GetMbrSts()
        {
            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.MemberStatuses.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.StatusId, val = item.Status });
                }
            }
            return Ok(a);
        }
        [HttpGet]
        [Route("GetCardStatus")]
        public IActionResult GetCardStatus()
        {
            List<LbVm> a = new List<LbVm>();
            using (BelayaRusV5Context db = new BelayaRusV5Context())
            {
                var e = db.PartyCardStatuses.ToList();
                foreach (var item in e)
                {
                    a.Add(new LbVm { id = item.Id, val = item.Status });
                }
            }
            return Ok(a);
        }*/
    }
}