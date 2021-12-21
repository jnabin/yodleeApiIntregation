using System.ComponentModel.DataAnnotations;

namespace YodleeIntegration.Application.Request.DataExtracts
{
    public class EventsRequest : BaseRequest
    {
        [Required(ErrorMessage = "From Date is empty.")]
        public string FromDate { get; set; }

        [Required(ErrorMessage = "Event Name is empty.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "To Date is empty.")]
        public string ToDate { get; set; }
    }
}