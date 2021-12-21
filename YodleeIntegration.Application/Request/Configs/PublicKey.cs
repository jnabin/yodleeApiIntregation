using System.Text.Json.Serialization;

namespace YodleeIntegration.Domain.Entities.Configs
{
    public class PublicKey
    {
        public string Alias { get; set; }

        public string Key { get; set; }
    }
}