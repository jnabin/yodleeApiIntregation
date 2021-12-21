using Microsoft.AspNetCore.Mvc;

namespace YodleeIntegration.Application.Request.Authorization
{
    public class ApiKeyRequest : BaseRequest
    {
        [FromQuery(Name = "publicKey")]
        public string PublicKey { get; set; }
    }
}