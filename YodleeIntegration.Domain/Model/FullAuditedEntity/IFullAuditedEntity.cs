using System;
using YodleeIntegration.Domain.Model.Entity;

namespace YodleeIntegration.Domain.Model.FullAuditedEntity
{
    public interface IFullAuditedEntity: IEntity
    {
        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}