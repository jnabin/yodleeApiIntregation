using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.Document
{
    public class DownloadDocumentRequest : BaseRequest
    {
        [Required(ErrorMessage = "document Id is empty.")]
        public string DocumentId { get; set; }
    }
}