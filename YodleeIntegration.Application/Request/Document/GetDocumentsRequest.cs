using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.Document
{
    public class GetDocumentsRequest : BaseRequest
    {
        [Required(ErrorMessage = "Keyword is empty.")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "document Id is empty.")]
        public string AccountId { get; set; }

        [Required(ErrorMessage = "doc Type is empty.")]
        public string DocType { get; set; }

        [Required(ErrorMessage = "from Date is empty.")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "to Date is empty.")]
        public string ToDate { get; set; }
    }
}