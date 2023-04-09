using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TaskScheduler.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public AccountController(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public IActionResult GetLoggedinUser()
        {
            var user = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View();
        }
    }
}
