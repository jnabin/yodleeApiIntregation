using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Entities;
namespace YodleeIntegration.Application.Response
{
    public class AccountResponse
    {
        [JsonPropertyName("account")]
        public List<Account> Account { get; set; }
    }
}
