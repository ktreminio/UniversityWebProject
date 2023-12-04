namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping
{
    public interface IPropertyMappingService<TSource, TDestination>
    {
        bool ValidMappingExistsFor(string fields);

        Dictionary<string, PropertyMappingValue> GetPropertyMapping();
    }
}
