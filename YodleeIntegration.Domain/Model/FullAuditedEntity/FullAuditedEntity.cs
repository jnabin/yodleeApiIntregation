using System;

namespace YodleeIntegration.Domain.Model.FullAuditedEntity
{
    public class FullAuditedEntity: Entity.Entity, IFullAuditedEntity
    {
        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }

        protected FullAuditedEntity() => this.CreationTime = DateTime.Now;
    }
}
