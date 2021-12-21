using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request
{
    public class TransactionSummaryRequest : BaseRequest
    {
        [Required(ErrorMessage = "Account Ids is empty.")]
        public string AccountIds { get; set; }

        [Required(ErrorMessage = "Category Id is empty.")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Category Type is empty.")]
        public string CategoryType { get; set; }

        [Required(ErrorMessage = "From Date is empty.")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "Group By is empty.")]
        public string GroupBy { get; set; }

        [Required(ErrorMessage = "Include is empty.")]
        public string Include { get; set; }

        [Required(ErrorMessage = "Include User Category is empty.")]
        public string IncludeUserCategory { get; set; }

        [Required(ErrorMessage = "Interval is empty.")]
        public string Interval { get; set; }

        [Required(ErrorMessage = "To Date is empty.")]
        public string ToDate { get; set; }
    }
}