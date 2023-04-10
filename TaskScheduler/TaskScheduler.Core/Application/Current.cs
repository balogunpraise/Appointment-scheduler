using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TaskScheduler.Core.Application.Extensions;
using TaskScheduler.Core.Entities;

namespace TaskScheduler.Core.Application
{
    public static class Current
    {
        private static IHttpContextAccessor _httpContextAccessor;
        private static UserManager<ApplicationUser> _userManager;
        private static string _userId;
        private static ApplicationUser _user;

        public static async Task SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userId = httpContextAccessor?.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            _user = _userId.IsNotNullOrEmpty() ? await _userManager.FindByIdAsync(_userId) : null;


        }
        public static string CurrentUserId
        {
            get
            {
                return _userId;
            }
        }


        public static ApplicationUser User
        {
            get
            {
                return _user;
            }
        }



        public static string DisplayName
        { 
            get 
            {
                return _user.UserName;
            } 
        }

        public static string BusinessId
        {
            get
            {
                return _user.BusinessId;
            }
        }
    

        public static string BusinessName
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
