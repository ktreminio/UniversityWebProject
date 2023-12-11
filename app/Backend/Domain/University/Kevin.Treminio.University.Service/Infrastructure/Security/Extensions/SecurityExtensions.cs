using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Kevin.Treminio.University.Service.Infrastructure.Security.Extensions
{
    public static class SecurityExtensions
    {
        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => 
            { 
                options.Authority = "http://keycloak:8080/realms/university";
                options.Audience = "university.service";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:8081/realms/university",
                    ValidateAudience = true,
                    ValidAudience = "university.service",
                    ValidateLifetime = true
                };
            });

            services.AddSingleton<IClaimsTransformation, RoleClaimsTransformer>();
            services.AddAuthorization();
        }
    }
}
