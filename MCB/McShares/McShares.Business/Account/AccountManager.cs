using McShares.Core.ViewModels;
using McShares.Core.ViewModels.Account;
using System.Threading.Tasks;

namespace McShares.Business.Account
{
    public class AccountManager : IAccountManager
    {
        public async Task<DataProcessResponseModel> ValidUser(UserInfo userInfo)
        {
            if (userInfo.Email.ToLower() == "mcshares@gmail.com" && userInfo.Password.ToLower() == "mcshares@123")
            {
                return new DataProcessResponseModel { IsSuccess = true, Message = "Login Successfully.", RowId = 1 };
            }
            else
            {
                return new DataProcessResponseModel { IsSuccess = false, Message = "Invalid Credential.", RowId = 0 };
            }
        }
    }
}
