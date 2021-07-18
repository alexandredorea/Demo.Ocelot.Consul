using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

namespace Demo.Microservico.ApiGateway
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot().AddConsul();
            //services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //app.UseRouting();
            app.UseHttpsRedirection();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Api Gateway Funcionando!"); });
            //});

            app.UseOcelot().Wait();
        }
    }
}