using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YodleeIntegration.Application.Request
{
    public class UpdateCategoryRequestBody
    {
        [JsonPropertyName("highLevelCategoryName")]
        public string HighLevelCategoryName { get; set; }

        [JsonPropertyName("id")]
        
        [Required(ErrorMessage = "id is empty.")]
        public int Id { get; set; }

        [JsonPropertyName("source")]
        
        [Required(ErrorMessage = "Source is empty.")]
        public string Source { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }
    }
}