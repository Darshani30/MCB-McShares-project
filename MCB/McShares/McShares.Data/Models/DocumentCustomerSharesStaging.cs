using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McShares.Data.Models
{
    public class DocumentCustomerSharesStaging
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentCustomerSharesStagingId { get; set; }
        public string CustomerNo { get; set; }
        public bool IsError { get; set; }
        public string ValidationSummary { get; set; }
    }
}
