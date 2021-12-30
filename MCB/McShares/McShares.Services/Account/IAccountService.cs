using McShares.Core.ViewModels;
using McShares.Core.ViewModels.Account;
using System.Threading.Tasks;

namespace McShares.Services.Account
{
    public interface IAccountService
    {
        Task<DataProcessResponseModel> ValidUser(UserInfo userInfo);
    }
}
