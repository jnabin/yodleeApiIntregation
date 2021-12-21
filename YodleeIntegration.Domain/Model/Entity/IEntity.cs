namespace YodleeIntegration.Domain.Model.Entity
{
    public interface IEntity
    {
        public long EntityId { get; set; }

        public bool IsActive { get; set; }
    }
}
