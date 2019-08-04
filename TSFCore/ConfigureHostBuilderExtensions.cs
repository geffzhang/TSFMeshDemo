using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace TSF.Tracing.Propagation
{
    /// <summary>
    /// Adds extensions to the IWebHostBuilder.
    /// </summary>
    public static class ConfigureHostBuilderExtensions
    {
        /// <summary>
        /// Sets up the Propagation of Envoy headers from input requests to outgoing requests.
        /// </summary>
        /// <param name="hostBuilder">The hostbuilder.</param>
        /// <returns>Returns the configured hostbuilder.</returns>
        public static IWebHostBuilder PropagateEnvoyHeaders(this IWebHostBuilder hostBuilder)
        {
            if (hostBuilder == null)
                throw new ArgumentNullException(nameof(hostBuilder));

            return hostBuilder.ConfigureServices((services) =>
            {
                services.AddHttpContextAccessor();

                services.TryAddTransient<EnvoyHeadersFetcherMiddleware>();
                services.TryAddTransient<HeadersPropagationDelegatingHandler>();

                services.TryAddScoped<IEnvoyHeadersHolder,EnvoyHeadersHolder>();

                // This will setup everything automagically
                services.AddSingleton<IHttpMessageHandlerBuilderFilter, HeadersPropagationMessageHandlerBuilderFilter>();
                services.AddSingleton<IStartupFilter, EnvoyHeadersFetcherMiddlewareStartupFilter>();
            });
        }

    }
}
