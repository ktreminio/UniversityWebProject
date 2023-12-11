using System.Text.Json.Serialization;

namespace Kevin.Treminio.University.Service.Infrastructure.Security.Extensions
{
    public class AccessRoles
    {
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }
    }
}
