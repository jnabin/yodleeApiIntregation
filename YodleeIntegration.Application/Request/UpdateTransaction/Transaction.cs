using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YodleeIntegration.Domain.Entities.UpdateTransaction
{
    public class Transaction
    {
        [Required(ErrorMessage = "Category Source is empty.")]
        public string CategorySource { get; set; }

        [Required(ErrorMessage = "Container is empty.")]
        public string Container { get; set; }

        public bool IsPhysical { get; set; }

        public int DetailCategoryId { get; set; }

        public Description Description { get; set; }

        public string Memo { get; set; }

        public string MerchantType { get; set; }

        public int CategoryId { get; set; }
    }
}