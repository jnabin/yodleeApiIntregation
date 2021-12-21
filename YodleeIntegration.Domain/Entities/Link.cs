using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Link : FullAuditedEntity
    {
        public string MethodType { get; set; }
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}