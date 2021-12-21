using YodleeIntegration.Domain.Model.FullAuditedEntity;


namespace YodleeIntegration.Domain.Entities
{
    public class PublicKey : FullAuditedEntity
    {
        public string Alias { get; set; }

        public string Key { get; set; }
    }
}