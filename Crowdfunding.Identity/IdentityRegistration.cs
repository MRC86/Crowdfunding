using Crowdfunding.Identity.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Crowdfunding.Identity.Models;

namespace Crowdfunding.Identity
{
    public static class IdentityRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddScoped<JWTService>();
            #endregion

            #region Auth
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {

                jwtOptions.SaveToken = true;
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.Configuration = new OpenIdConnectConfiguration();
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("BackendJwtTokenConfig:Secret"))),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMilliseconds(1)
                };
            });
            services.AddAuthorization();
            var backendJwtTokenConfig = configuration.GetSection("BackendJwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton<JwtTokenConfig>(backendJwtTokenConfig);

            services.AddHttpContextAccessor();
            services.AddScoped<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            #endregion




            return services;
        }
    }
}
