using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskScheduler.Core.Entities;
using TaskScheduler.Infrastructure.Data.Repositories;

namespace TaskScheduler.Api
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service, IConfiguration config)
        {
            var builder = service.AddIdentity<ApplicationUser, IdentityRole>();
            builder.AddEntityFrameworkStores<EfContext>().AddDefaultTokenProviders();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();

            service.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });
            return service;
        }
    }
}
