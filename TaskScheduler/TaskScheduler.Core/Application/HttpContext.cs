using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _httpContextAccessor;


        public static Microsoft.AspNetCore.Http.HttpContext Current => _httpContextAccessor.HttpContext;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }


}
