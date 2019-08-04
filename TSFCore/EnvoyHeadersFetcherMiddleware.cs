using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSF.Tracing.Propagation
{
    public class EnvoyHeadersFetcherMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvoyHeadersFetcherMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <exception cref="ArgumentNullException">next</exception>
        public EnvoyHeadersFetcherMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Extracts the envoy headers from the request and adds them to the headers holder.
        /// </summary>
        /// <param name="context">The current http context.</param>
        /// <param name="envoyHeaders">The envoy headers holder for the current request.</param>
        /// <returns>
        /// The task object representing the asynchronous operation.
        /// </returns>
        public Task InvokeAsync(HttpContext context, IEnvoyHeadersHolder envoyHeaders)
        {
            envoyHeaders.RequestId = GetHeader(context, EnvoyHeaders.REQUEST_ID);
            envoyHeaders.B3TraceId = GetHeader(context, EnvoyHeaders.B3_TRACE_ID);
            envoyHeaders.B3SpanId = GetHeader(context, EnvoyHeaders.B3_SPAN_ID);
            envoyHeaders.B3ParentSpanId = GetHeader(context, EnvoyHeaders.B3_PARENT_SPAN_ID);
            envoyHeaders.B3Sampled = GetHeader(context, EnvoyHeaders.B3_SAMPLED);
            envoyHeaders.B3Flags = GetHeader(context, EnvoyHeaders.B3_FLAGS);
            envoyHeaders.OtSpanContext = GetHeader(context, EnvoyHeaders.OT_SPAN_CONTEXT);
            envoyHeaders.TraceService = GetHeader(context, EnvoyHeaders.Trace_Service);
            envoyHeaders.ClientTraceId = GetHeader(context, EnvoyHeaders.Client_Trace_ID);
            return next(context);
        }


        private string GetHeader(HttpContext context, string headerName)
        {
            if (context.Request.Headers.TryGetValue(headerName, out var values))
            {
                var firstValue = values.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(firstValue))
                    return firstValue;
            }

            return null;
        }
    }
}
