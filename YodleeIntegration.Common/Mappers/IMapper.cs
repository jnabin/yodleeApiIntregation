namespace YodleeIntegration.Common.Mappers
{
    public interface IMapper<out TDestination, TSource>
    where TDestination : class
    where TSource : class
    {
        TDestination Map();
    }
}