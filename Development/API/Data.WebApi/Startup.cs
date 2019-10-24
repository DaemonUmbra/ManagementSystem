﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AutoMapper;
using Data.WebApi.Configuration;
using Data.WebApi.Mapping;
using Data.WebApi.Services.Authorization;
using Data.WebApi.Services.Core;
using Data.WebApi.Services.UserResolving;
using IdentityServer4.AccessTokenValidation;
using Mcms.Api.Data.EfCore.Context;
using Mcms.Api.Data.EfCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Data.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<MCMSContext>();

            services.AddEfCoreDataLayer(opt =>
                opt.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"])
                );

            services.AddAutoMapper(
                typeof(ApiModelMappingProfile)
            );

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    Configuration.GetSection("AuthenticationServerConfig").Bind(options);
                });


            services.AddSwaggerGen(config =>
            {
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

                config.SwaggerDoc("v1", new Info()
                {
                    Contact = new Contact()
                    {
                        Email = "mcms.service@test.com",
                        Url = "https://mcmstest.ldtteam.com",
                        Name = "mcms.service - Development team"
                    },
                    Description = "OpenAPI documentation for the MCMS Data.WebApi.",
                    License = new License()
                    {
                        Name = "GPL v3",
                    },
                    Title = "MCMS.Data.WebApi - OpenAPI Documentation",
                    Version = "0.1"
                });

                var customBoundJwtOptions = new AuthenticationConfiguration();
                Configuration.GetSection("AuthenticationServerConfig").Bind(customBoundJwtOptions);

                config.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Flow = "implicit",
                    AuthorizationUrl = $"{customBoundJwtOptions.Authority}/connect/authorize",
                    Scopes = new Dictionary<string, string> {
                        { customBoundJwtOptions.ApiName, "MCMS.Api" }
                    }
                });

                config.OperationFilter<AuthorizeCheckOperationFilter>(customBoundJwtOptions);

                config.DescribeAllEnumsAsStrings();
            });

            services.AddTransient<IUserResolvingService, AuthorizationBasedUserResolvingService>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health");

            app.UseHttpsRedirection();

            app.UseMvc();

            var customBoundJwtOptions = new AuthenticationConfiguration();
            Configuration.GetSection("AuthenticationServerConfig").Bind(customBoundJwtOptions);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MCMS.Data.WebApi - OpenAPI Documentation");

                c.OAuthClientId(customBoundJwtOptions.SwaggerUIClientId);
                c.OAuthClientSecret(customBoundJwtOptions.SwaggerUIClientSecret);
                c.OAuthAppName(customBoundJwtOptions.ApiName);
            });

            //app.AddDatabaseMigrations();
        }
    }
}
