using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YodleeIntegration.Domain.Model.RequestLog
{
    [Table("YodleeWrapperIntegrationRequestLog")]
    public class RequestLog : Entity.Entity
    {
        public string UserName { get; set; }

        public string Endpoint { get; set; }

        public string Method { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        public string ReasonPhrase { get; set; }

        public DateTime TimeStamp { get; set; }

        public RequestLog() => TimeStamp = DateTime.Now;
    }
}
