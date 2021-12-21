using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace YodleeIntegration.Api.Extensions
{
    public static class ModelStateExtension
    {
        public static string GetErrors(this ModelStateDictionary modelState)
        {
            return string.Join(",", modelState.Values
                                         .SelectMany(x => x.Errors)
                                         .Select(x => x.ErrorMessage));
        }
    }
}