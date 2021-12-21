using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.DataExtracts
{
    public class UserDataRequest : BaseRequest
    {
        [Required(ErrorMessage = "From Date is empty.")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "Login Name is empty.")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "To Date is empty.")]
        public string ToDate { get; set; }
    }
}