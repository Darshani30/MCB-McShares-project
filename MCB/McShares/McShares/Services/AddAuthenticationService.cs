using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace McShares.Services
{
    public static class ServiceConfigurations
    {
        public static void AddAuthenticationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option => {
                    option.SlidingExpiration = true;
                    option.Cookie.HttpOnly = true;
                    option.Cookie.IsEssential = true;
                    option.LoginPath = "/Account/login";
                    option.LogoutPath = "/Account/logout";
                    option.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = OnValidatePrincipal
                    };
                });
        }

        private static async Task OnValidatePrincipal(CookieValidatePrincipalContext context)
        {
            if (context != null && context.Principal.Identity.IsAuthenticated)
            {
                string jwtToke = context.HttpContext.Session.GetString("jwttoken");
                //context.HttpContext.Request.Headers. DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", "Your Oauth token");
            }
            else
            {
                context.RejectPrincipal();
                context.HttpContext.Session.Clear();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

    }
}
