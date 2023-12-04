namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping
{
    public class PropertyMappingValue
    {
        public IEnumerable<string> DestinationProperties { get; private set; }
        public bool Revert { get; private set; }

        public PropertyMappingValue(IEnumerable<string> destinationProperties,
            bool revert = false)
        {
            DestinationProperties = destinationProperties;
            Revert = revert;
        }
    }
}
