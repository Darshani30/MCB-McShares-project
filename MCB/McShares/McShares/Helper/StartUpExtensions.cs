using Microsoft.Extensions.DependencyInjection;
using McShares.Services.Account;
using McShares.Business.Account;


namespace McShares.Helper
{
    public class StartUpExtensions
    {
        public static void AddMappingConfiguration(ref IServiceCollection services)
        {

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountManager, AccountManager>();
        }
    }
}
