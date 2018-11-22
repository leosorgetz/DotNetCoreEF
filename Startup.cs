using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTesteDotNet.HyperMidia;
using DotNetCoreEF.Business;
using DotNetCoreEF.Business.Implementation;
using DotNetCoreEF.Model.Context;
using DotNetCoreEF.Repository;
using DotNetCoreEF.Repository.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tapioca.HATEOAS;

namespace DotNetCoreEF
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString));
            services.AddMvc();

            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddApiVersioning();
            //var filterOptions = new HyperMediaFilterOptions();
            //filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            //services.AddSingleton(filterOptions);   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "DefaultApi",
            //        template: "{controller=Values}/{id?}"
            //        );
            //});
            app.UseMvc();
        }
    }
}
