using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request
{
    public class AuthorizationUserTokenRequest : BaseRequest
    {
        [Required(ErrorMessage = "Client Id is empty.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Client secret is empty.")]
        public string Secret { get; set; }
    }
}
