using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskScheduler.Core.Entities;

namespace TaskScheduler.Core.Application
{
    public static class Current
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public static string CurrentUserId
        {
            get
            {
                return _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }


        public static ApplicationUser User
        {
            get
            {
                ApplicationUser user = null;
                if(CurrentUserId != null)
                {
                    //todo
                }
                return user;
            }
        }



        public static string DisplayName
        { 
            get 
            {
                return "09Ujdljud-09kdkn-oujdm";
            } 
        }

        public static string BusinessId
        {
            get
            {
                return "09Ujdljud-09kdkn-oujdm";
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
