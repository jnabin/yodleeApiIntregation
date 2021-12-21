using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YodleeIntegration.Api.Models.Authorization
{
    public class TokenParams
    {
        [BindRequired]
        [FromQuery(Name = "username")]
        public string Username { get; set; }
    }
}
