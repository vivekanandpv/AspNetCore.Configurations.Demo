using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Configurations.Demo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    IConfigurationSection personSection = _configuration.GetSection("Person");

                    var firstName = personSection.GetValue<string>("FirstName");

                    IConfigurationSection friendsSection = _configuration.GetSection("Friends");

                    var friends = friendsSection.Get<string[]>();

                    var year = _configuration.GetValue<int>("Year");
                    var shouldGreet = _configuration.GetValue<bool>("ShouldGreet");


                    //  shorter version
                    //var friends = _configuration.GetSection("Friends").Get<string[]>();

                    await context.Response.WriteAsync(firstName);
                });
            });
        }
    }
}
