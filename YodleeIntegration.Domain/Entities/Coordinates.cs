using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Coordinates : FullAuditedEntity
    {
        public int Latitude { get; set; }

        public int Longitude { get; set; }
    }
}