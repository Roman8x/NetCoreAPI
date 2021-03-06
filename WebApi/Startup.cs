﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Models;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebApi.Filter;
using WebApi.Repository;

namespace WebApi
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст DP_MainContext в качестве сервиса в приложение
            services.AddDbContext<DP_MainContext>(option => option.UseSqlServer (connectionString) );
            DependencyInjection(services);
            services.AddAuthentication(x => 
            {
            });


            services.AddMvc(
                options => 
                {
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    options.Filters.Add(typeof(AuthorizationStmFilter));
                }
                )
                .AddXmlSerializerFormatters();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);            
        }

        private void DependencyInjection(IServiceCollection services) {
            services.AddScoped<AuthorizationStmFilter>();
            services.AddScoped<IDtBaseRepository,        DtBaseRepository>();
            services.AddScoped<IDtTechRepository,        DtTechRepository>();
            services.AddScoped<IRefMediaTypeRepository , RefMediaTypeRepository>();
            services.AddScoped<IRefPartnersRepository,   RefPartnersRepository>();
            services.AddScoped<IStmApiClientsRepository, StmApiClientsRepository>();
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
            app.UseMvc();          
        }
    }
}
