using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TSF.Tracing.Propagation;

namespace User
{
    public class Startup
    {
        bool running = true;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpClient("shopclient", x => {
                x.BaseAddress = new Uri("http://shop");
                x.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            })
                .AddHttpMessageHandler((provider) =>
                {
                    return new TraceServiceHttpMessageHandler() { Header = "user" };
                });

            services.AddHealthChecks()
            .AddCheck("health", () => running ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("health")
            });
            app.UseExceptionMiddleware();
            app.UseMvc();
        }
    }
}
