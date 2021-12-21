using System.ComponentModel.DataAnnotations;
using YodleeIntegration.Domain.Entities;

namespace YodleeIntegration.Application.Request
{
    public class EvaluateAddressRequestBody
    {
        [Required(ErrorMessage = "Address is empty.")]
        public Address Address { get; set; }
    }
}