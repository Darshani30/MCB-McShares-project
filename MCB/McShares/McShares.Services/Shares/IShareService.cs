using McShares.Core.ViewModels.Shares;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McShares.Services.Shares
{
    public interface IShareService
    {
        Task<List<ResponseXML>> SaveCustomerFromXml(string xml);

        Task<List<CustomerViewModel>> GetAllRecords(string contactname);

        Task<string> UpdateRecord(AllDetailsViewModel customer);
    }
}
