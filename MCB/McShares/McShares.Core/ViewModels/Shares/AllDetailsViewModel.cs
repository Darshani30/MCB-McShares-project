using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McShares.Core.ViewModels.Shares
{
    public class AllDetailsViewModel
    {
        [Required(ErrorMessage = "CustomerNo Required.")]
        [Display(Name = "Customer Id")]
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string RegistrationNo { get; set; }
        [Display(Name = "No Of Shares")]
        public int Shares { get; set; }
        [Display(Name = "Shares Price")]
        [Range(0, 9999999.99)]
        public decimal Price { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string TownCity { get; set; }
        public string Country { get; set; }
    }
}
