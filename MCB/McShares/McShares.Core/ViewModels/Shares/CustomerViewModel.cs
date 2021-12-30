
using System;

namespace McShares.Core.ViewModels.Shares
{
    public class CustomerViewModel
    {
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateInCorporate { get; set; }
        public string RegistrationNo { get; set; }
        public int Shares { get; set; }
        public decimal Price { get; set; }
        public decimal Balance { get; set; }
    }
}
