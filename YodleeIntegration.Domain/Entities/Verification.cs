using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    [Table("YodleeVerification")]
    public class Verifications : FullAuditedEntity
    {
        public long AccountId { get; set; }

        public string Reason { get; set; }

        public string VerificationStatus { get; set; }

        public long ProviderAccountId { get; set; }

        public string VerificationType { get; set; }

        public VerificationAccount Account { get; set; }

        public int RemainingAttempts { get; set; }

        public string VerificationDate { get; set; }

        public long YodleeVerificationId { get; set; }
    }
}