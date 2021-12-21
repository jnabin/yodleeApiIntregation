using System.Collections.Generic;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class Row : FullAuditedEntity
    {
        public string FieldRowChoice { get; set; }

        public List<Field> Field { get; set; }

        public string Form { get; set; }

        public string YodleeRowId { get; set; }

        public string Label { get; set; }
    }
}