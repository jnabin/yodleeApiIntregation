using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.Derived
{
    public class HoldingSummaryRequest : BaseRequest
    {
        [Required(ErrorMessage = "Account Ids is empty.")]
        public string AccountIds { get; set; }

        [Required(ErrorMessage = "classificationType is empty.")]
        public string ClassificationType { get; set; }

        [Required(ErrorMessage = "Include is empty.")]
        public string Include { get; set; }
    }
}