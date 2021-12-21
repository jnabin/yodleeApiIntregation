using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request.Document
{
    public class DeleteDocumentRequest : BaseRequest
    {
        [Required(ErrorMessage = "document Id is empty.")]
        [JsonPropertyName("documentId")]
        public string DocumentId { get; set; }
    }
}
