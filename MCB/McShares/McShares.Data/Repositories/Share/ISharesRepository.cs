using McShares.Core.ViewModels.Shares;
using McShares.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McShares.Data.Repositories.Share
{
    public interface ISharesRepository
    {
        Task<List<DocumentCustomerSharesStaging>> SaveCustomerFromXml(string xml);

        Task<List<Customer>> GetAllRecords(string contactname);

        Task<string> UpdateRecord(AllDetailsViewModel customer);
    }
}
