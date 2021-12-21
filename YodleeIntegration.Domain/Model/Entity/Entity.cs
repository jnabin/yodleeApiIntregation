using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YodleeIntegration.Domain.Model.Entity
{
    public class Entity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EntityId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
