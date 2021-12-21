using System.Collections.Generic;
using System.Text.Json.Serialization;
using YodleeIntegration.Domain.Model.FullAuditedEntity;

namespace YodleeIntegration.Domain.Entities
{
    public class LoginForm : FullAuditedEntity
    {
        public string MfaInfoTitle { get; set; }

        public string Help { get; set; }

        public string ForgetPasswordURL { get; set; }

        public string FormType { get; set; }

        public string MfaInfoText { get; set; }

        public string LoginHelp { get; set; }

        public int MfaTimeout { get; set; }

        [JsonPropertyName("id")]
        public int YodleeLoginFormId { get; set; }

        public List<Row> Row { get; set; }
    }
}