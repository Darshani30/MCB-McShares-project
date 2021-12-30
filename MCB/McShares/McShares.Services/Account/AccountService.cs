using McShares.Business.Account;
using McShares.Core.ViewModels;
using McShares.Core.ViewModels.Account;
using System.Threading.Tasks;

namespace McShares.Services.Account
{
    public class AccountService : IAccountService
    {
        #region Declare Variables
        private readonly IAccountManager _accountManager;
        #endregion

        #region Constructor
        public AccountService(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }
        #endregion

        public async Task<DataProcessResponseModel> ValidUser(UserInfo userInfo)
        {
            return await _accountManager.ValidUser(userInfo);
        }
    }
}
