using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.Derived
{
    public class NetworthSummaryRequest : BaseRequest
    {
        [Required(ErrorMessage = "Account Ids is empty.")]
        public string AccountIds { get; set; }

        [Required(ErrorMessage = "Container is empty.")]
        public string Container { get; set; }

        [Required(ErrorMessage = "From Date is empty.")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "Include is empty.")]
        public string Include { get; set; }

        [Required(ErrorMessage = "Interval is empty.")]
        public string Interval { get; set; }

        [Required(ErrorMessage = "Skip is empty.")]
        public string Skip { get; set; }

        [Required(ErrorMessage = "To Date is empty.")]
        public string ToDate { get; set; }

        [Required(ErrorMessage = "Top is empty.")]
        public string Top { get; set; }
    }
}