namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
