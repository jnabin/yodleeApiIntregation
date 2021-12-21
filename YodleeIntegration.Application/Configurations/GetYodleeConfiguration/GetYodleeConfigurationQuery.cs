using MediatR;
using YodleeIntegration.Domain.Model.Configurations;

namespace YodleeIntegration.Application.Configurations.GetYodleeConfiguration
{
    public record GetYodleeConfigurationQuery() : IRequest<YodleeConfiguration>;
}
