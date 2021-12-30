using McShares.Core.ViewModels;
using McShares.Core.ViewModels.Account;
using System.Threading.Tasks;

namespace McShares.Business.Account
{
    public interface IAccountManager
    {
        Task<DataProcessResponseModel> ValidUser(UserInfo userInfo);
    }
}
