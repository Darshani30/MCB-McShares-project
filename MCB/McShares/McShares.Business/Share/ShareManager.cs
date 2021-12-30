using McShares.Core.ViewModels.Shares;
using McShares.Data.Models;
using McShares.Data.Repositories.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McShares.Business.Share
{
    public class ShareManager : IShareManager
    {
        #region Declare Variables
        private readonly ISharesRepository _sharesRepository;
        #endregion

        #region Constructor
        public ShareManager(ISharesRepository sharesRepository)
        {
            _sharesRepository = sharesRepository;
        }
        #endregion

        #region Methods
        public async Task<List<ResponseXML>> SaveCustomerFromXml(string xml)
        {
            var list = await _sharesRepository.SaveCustomerFromXml(xml);
            List<ResponseXML> response = list.Select(x => new ResponseXML()
            {
                CustomerNo = x.CustomerNo,
                IsSuccess = (x.IsError == true ? false : true),
                ValidationSummary = x.ValidationSummary
            }).ToList();

            return response;
        }

        public async Task<List<CustomerViewModel>> GetAllRecords(string contactname)
        {

            var list = await _sharesRepository.GetAllRecords(contactname);
            List<CustomerViewModel> response = list.Select(x => new CustomerViewModel()
            {
                CustomerNo = x.CustomerNo,
                CustomerName = x.CustomerName,
                CustomerType = x.CustomerType,
                DateOfBirth = x.DateOfBirth,
                DateInCorporate = x.DateInCorporate,
                RegistrationNo = x.RegistrationNo,
                Shares = x.Shares,
                Price = x.Price,
                Balance = x.Balance,

            }).ToList();

            return response;
        }



        public async Task<string> UpdateRecord(AllDetailsViewModel customer)
        {
            return await _sharesRepository.UpdateRecord(customer);
           
        }
        #endregion


    }
}
