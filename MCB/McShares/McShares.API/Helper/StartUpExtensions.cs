using McShares.API.Services.File;
using McShares.Business.Account;
using McShares.Business.Share;
using McShares.Data.Repositories.Share;
using McShares.Services.Account;
using McShares.Services.Shares;
using Microsoft.Extensions.DependencyInjection;


namespace McShares.API.Helper
{
    public class StartUpExtensions
    {
        public static void AddMappingConfiguration(ref IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IShareService, ShareService>();
            services.AddTransient<IShareManager, ShareManager>();
            services.AddTransient<ISharesRepository, SharesRepository>();
        }
    }
}
