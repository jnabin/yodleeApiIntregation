using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Data : FullAuditedEntity
    {
        public string FromDate { get; set; }
        public List<DataExtractUserData> UserData { get; set; }
        public int UserCount { get; set; }
        public string ToDate { get; set; }
    }
}