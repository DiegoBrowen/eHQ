using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using eHQ.EventBus.Extensions;
using eHQ.IntegrationEventLog;
using eHQ.IntegrationEventLog.Extensions;
using eHQ.Produto.Api.Data;
using eHQ.Produto.Api.IntegrationEvents.Interfaces;
using eHQ.Produto.Api.IntegrationEvents.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace eHQ.Produto.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ProdutoContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(assemblyName));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();
            services.AddEventBus(Configuration)
                    .AddIntegrationEventService<IProdutoIntegrationEventService, ProdutoIntegrationEventService>();

            services.AddIntegrationEventLog(assemblyName, connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
