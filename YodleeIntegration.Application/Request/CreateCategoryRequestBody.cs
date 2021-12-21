using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request
{
    public class CreateCategoryRequestBody
    {
        [JsonPropertyName("parentCategoryId")]
        [Required(ErrorMessage = "Parent Category Id is empty.")]
        public int ParentCategoryId { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }
    }
}