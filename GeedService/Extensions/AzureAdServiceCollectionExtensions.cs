using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GeedService.Extensions
{
    public static class AzureAdServiceCollectionExtensions
    {
        public static AuthenticationBuilder AddAzureAdB2CBearer(this AuthenticationBuilder builder)
            => builder.AddAzureAdB2CBearer(_ => { });

        public static AuthenticationBuilder AddAzureAdB2CBearer(this AuthenticationBuilder builder, Action<AzureAdB2COptions> configureOptions)
        {
            builder.Services.Configure(configureOptions);
            builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureAzureOptions>();
            builder.AddJwtBearer();
            return builder;
        }

        private class ConfigureAzureOptions : IConfigureNamedOptions<JwtBearerOptions>
        {
            private readonly AzureAdB2COptions _azureOptions;

            public ConfigureAzureOptions(IOptions<AzureAdB2COptions> azureOptions)
            {
                _azureOptions = azureOptions.Value;
            }

            public void Configure(string name, JwtBearerOptions options)
            {
                options.Audience = _azureOptions.ClientId;
                options.Authority = $"{_azureOptions.Instance}/{_azureOptions.Domain}/{_azureOptions.SignUpSignInPolicyId}/v2.0";
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = AuthenticationFailed
                };
            }

            public void Configure(JwtBearerOptions options)
            {
                Configure(Options.DefaultName, options);
            }

            private Task AuthenticationFailed(AuthenticationFailedContext arg)
            {
                // For debugging purposes only!
                var s = $"AuthenticationFailed: {arg.Exception.Message}";
                arg.Response.ContentLength = s.Length;
                arg.Response.Body.Write(Encoding.UTF8.GetBytes(s), 0, s.Length);
                return Task.FromResult(0);
            }
        }
    }
}
