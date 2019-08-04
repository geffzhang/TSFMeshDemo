using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace TSF.Tracing.Propagation
{
    public class TraceServiceHttpMessageHandler : DelegatingHandler
    {
        public string Header { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.TryAddWithoutValidation(EnvoyHeaders.Trace_Service, Header);
            var response = base.SendAsync(request, cancellationToken);

            return response;
        }

    }
}
