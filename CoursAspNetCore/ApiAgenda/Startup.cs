using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiAgenda
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
            services.AddMvc();
            services.AddCors(options=> {
                options.AddPolicy("maPolice", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
                options.AddPolicy("Police2", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod();
                });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("espacePrive", policy => policy.Requirements.Add(new EspacePriveRequirement() { access = false}));
            });
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            //pour autoriser cross origin share
            //app.UseCors(options =>
            //{
            //    //Accepter tout le monde avec toutes les methodes
            //    options.AllowAnyOrigin().AllowAnyMethod();
            //    //accepter que http://monclient
            //    //options.WithOrigins("http://monclient").WithMethods("GET","POST","PUT","DELETE");

            //});
            app.UseCors("maPolice");
            app.UseCors("Police2");
        }
    }
}
