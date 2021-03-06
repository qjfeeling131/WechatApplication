﻿using Abp.DoNetCore;
using Abp.DoNetCore.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using WechatAPI.Core.Filters;
using WechatAPI.Core.Infrastructure;
using WechatAPI.Core.Module;

namespace WechatAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddOptions();
            //Add the authoriaztion 

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                           .RequireAuthenticatedUser()
                           .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "1.0 alpha",  //beta
                    Title = "Wechat API",
                    Description = "It's a back-end API for Wechat",
                    TermsOfService = "None",
                });
                //MimeoOAWeb
                //Set the comments path for the swagger json and ui.
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                var xmlPath = Path.Combine(basePath, "WechatAPI.xml");
                c.IncludeXmlComments(xmlPath);
            });

            //Set the amount of Master/Slave, and I know this setting is so digusting, but it need to do it for the moment. I will optimize this function as a middleware to implement the logic of Master/Slave
            services.Configure<Abp.EntityFrameworkCore.EFCoreDataBaseOptions>(options => {
                WechatConfiguration mimeoConfiguration = new WechatConfiguration();
                Configuration.GetSection("EntityFrameworkCore:MimeoConfiguration").Bind(mimeoConfiguration);
                options.DbConnections = new Dictionary<Abp.DBSelector, string>();
                options.DbConnections.Add(Abp.DBSelector.Master, mimeoConfiguration.MasterConnectionString);
                options.DbConnections.Add(Abp.DBSelector.Slave, mimeoConfiguration.SalveConnectIonString);
            });

            //Set the Redis Cache Configuration
            services.Configure<Abp.RedisCache.AbpRedisCacheOptions>(options => {
                Abp.RedisCache.AbpRedisCacheConfiguration redisCacheConfiguration = new Abp.RedisCache.AbpRedisCacheConfiguration();
                Configuration.GetSection("RedisCacheSection:Connections").Bind(redisCacheConfiguration);
                options.DbConnections = new Dictionary<Abp.DBSelector, string>();
                options.DbConnections.Add(Abp.DBSelector.Master, redisCacheConfiguration.MasterConnection);
                options.DbConnections.Add(Abp.DBSelector.Slave, redisCacheConfiguration.SlaveConnection);
                options.DatabaseId = redisCacheConfiguration.DataBaseId;
            });
           return services.AddAbp<WechatModule>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wechat Api V1");
            });
            app.UserAbp();
            app.UseMvc();
        }
    }
}
