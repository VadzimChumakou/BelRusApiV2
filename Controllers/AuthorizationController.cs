using BelRusApiV2.Models.EfModels;
using BelRusApiV2.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BelRusApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : Controller
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginVm model)
        {
            Console.WriteLine(model.login);
            Authorizatio user = new Authorizatio();
            using (BelayaRusV5Context context = new BelayaRusV5Context())
            {
                user = context.Authorizatios.Include(u => u.Role).Include(u => u.Member).FirstOrDefault(u => u.Login == model.login && u.Password == model.password);
            }
            if (user == null)
            {
                return NotFound();
            }
           
            var ew = new AuthResVm();
            ew.Id = user.MemberId;

            AccountCard accountCard = new AccountCard();
            using (BelayaRusV5Context context = new BelayaRusV5Context())
            {
                accountCard = context.AccountCards.Include(c => c.ChleniUzla).ThenInclude(c => c.Uzel).FirstOrDefault(c => c.Id == ew.Id);
            }
            ew.Role = user.Role.Role1;
            ew.name = accountCard.Name;
            ew.surname = accountCard.Surname;
            ew.parent = accountCard.Patronymic;
            ew.obl = accountCard.ChleniUzla.Uzel.Nazva; }
            
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,user.Role.Role1),
                    new Claim("Id",$"{user.Member.Id}")
                };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
            
            return Ok(ew);
        }
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
