using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TSF.Tracing.Propagation
{
    /// <summary>
    /// Responsible for adding the <see cref="EnvoyHeadersFetcherMiddleware"/> to the ASP.Net core middleware pipeline.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Hosting.IStartupFilter" />
    public class EnvoyHeadersFetcherMiddlewareStartupFilter :  IStartupFilter
    {
        /// <summary>
        /// Adds the <see cref="EnvoyHeadersFetcherMiddleware"/> to the pipeline.
        /// </summary>
        /// <param name="next">The next action.</param>
        /// <returns>Returns the configuration action.</returns>
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return (builder) =>
            {
                builder.UseMiddleware<EnvoyHeadersFetcherMiddleware>();

                next(builder);
            };

        }
    }
}
