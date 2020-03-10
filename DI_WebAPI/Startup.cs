using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI_WebAPI.Controllers;
using DI_WebAPI.DataReader;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DI_WebAPI
{
    public class Startup
    {
        readonly string CORSPolicy = "_CORSPolicy"; 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CORSPolicy, builder =>
                { builder.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod(); });
            });

            // Dependency Injection!
            //services.AddTransient<IDataReader, DBReader>();
            services.AddTransient<IDataReader, FileReader>();

            var FileReader = new FileReader();
            FileReader.loader = new FileLoader("DataReader/anotherFile.txt");
            PersonController pc = new PersonController(FileReader);
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(CORSPolicy);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
