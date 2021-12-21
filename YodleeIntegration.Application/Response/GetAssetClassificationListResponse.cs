using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Response
{
    public class GetAssetClassificationListResponse
    {
        [JsonPropertyName("assetClassificationList")]
        public List<AssetClassificationList> AssetClassificationList { get; set; }
    }
}
