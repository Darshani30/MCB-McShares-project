using McShares.Business.Share;
using McShares.Core.ViewModels.Shares;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McShares.Services.Shares
{
    public class ShareService : IShareService
    {
        #region Declare Variables
        private readonly IShareManager _shareManager;
        #endregion

        #region Constructor
        public ShareService(IShareManager shareManager)
        {
            _shareManager = shareManager;
        }
        #endregion

        public async Task<List<ResponseXML>> SaveCustomerFromXml(string xml)
        {
            return await _shareManager.SaveCustomerFromXml(xml);
        }

        public async Task<List<CustomerViewModel>> GetAllRecords(string contactname)
        {
            return await _shareManager.GetAllRecords(contactname);
        }

        public async Task<string> UpdateRecord(AllDetailsViewModel customer)
        {
            return await _shareManager.UpdateRecord(customer);
        }
    }
}
