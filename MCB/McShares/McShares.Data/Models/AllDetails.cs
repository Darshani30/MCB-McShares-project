using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace McShares.Data.Models
{
    public class AllDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CustomerId { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateInCorporate { get; set; }
        public string RegistrationNo { get; set; }
        public int Shares { get; set; }
        public decimal Price { get; set; }
        public decimal Balance { get; set; }
        public string ContactName { get; set; }
        public int ContactNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string TownCity { get; set; }
        public string Country { get; set; }
    }
}
