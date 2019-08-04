﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TSF.Tracing.Propagation
{
    // <summary>
    /// Keeps the envoy headers in memory.
    /// </summary>
    /// <seealso cref="TSF.Tracing.Propagation.IEnvoyHeadersHolder" />
    public class EnvoyHeadersHolder : IEnvoyHeadersHolder
    {
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        public string RequestId { get; set; }
        /// <summary>
        /// Gets or sets the b3 trace identifier.
        /// </summary>
        /// <value>
        /// The b3 trace identifier.
        /// </value>
        public string B3TraceId { get; set; }
        /// <summary>
        /// Gets or sets the b3 span identifier.
        /// </summary>
        /// <value>
        /// The b3 span identifier.
        /// </value>
        public string B3SpanId { get; set; }
        /// <summary>
        /// Gets or sets the b3 parent span identifier.
        /// </summary>
        /// <value>
        /// The b3 parent span identifier.
        /// </value>
        public string B3ParentSpanId { get; set; }
        /// <summary>
        /// Gets or sets the b3 sampled.
        /// </summary>
        /// <value>
        /// The b3 sampled.
        /// </value>
        public string B3Sampled { get; set; }
        /// <summary>
        /// Gets or sets the b3 flags.
        /// </summary>
        /// <value>
        /// The b3 flags.
        /// </value>
        public string B3Flags { get; set; }
        /// <summary>
        /// Gets or sets the ot span context.
        /// </summary>
        /// <value>
        /// The ot span context.
        /// </value>
        public string OtSpanContext { get; set; }

        /// <summary>
        /// Gets or sets the trace service
        /// </summary>
        public string TraceService { get ; set ; }

        /// <summary>
        /// Gets or sets x-client-trace-id
        /// </summary>
        public string ClientTraceId { get; set; }
    }
}
