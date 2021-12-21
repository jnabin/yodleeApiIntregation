using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.Document
{
    public class Document
    {
        public long AccountID { get; set; }
        public string LastUpdated { get; set; }
        public string FromType { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }

        [EnumDataType(typeof(DocType))]
        public DocType DocType { get; set; }
    }

    public enum DocType
    {
        STMT,
        TAX,
        EBILL
    }
}