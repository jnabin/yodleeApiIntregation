using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request.Document
{
    public class DocumentDownload
    {
        public string DocContent { get; set; }

        public string Id { get; set; }
    }
}