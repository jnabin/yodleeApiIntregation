using System.Collections.Generic;

namespace YodleeIntegration.Application.Request
{
    public class BaseRequest
    {
        public string Endpoint { get; set; }

        public IEnumerable<KeyValuePair<string, string>> QueryParameters { get; set; }

        public string Username { get; set; }
    }
}
