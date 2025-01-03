using System;
using System.Reflection;
using System.Security.Cryptography.Xml;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Utility.Enums;

namespace OverallAuth01.PlugInUnit
{
    /// <summary>
    /// swagger 插件
    /// </summary>
    public static class SwaggerPlugInUnit
    {
        /// <summary>
        /// Initial Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void InitSwagger(this IServiceCollection services)
        {
            // add swagger
            services.AddSwaggerGen(optinos =>
            {
                typeof(ModuleGroupEnum).GetEnumNames().ToList().ForEach(version =>
                {
                    optinos.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = "权限管理系统",
                        Version = "V2.0",
                        Description = "Basic Auth Manage System",
                        Contact = new OpenApiContact { Name = "TBD", Url = new Uri("http://www.bing.com") }
                    });

                });

                //反射获取接口及方法描述
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                optinos.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName), true);

                // 使用 Jwt
                optinos.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Enter a Bearer Token in textbox blow",
                    Name = "Authorization", // default name 
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // 让swagger遵守jwt协议
                optinos.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<String>()
                    }
                });
            }); 
        }
        /// <summary>
        /// swagger 加入路由和管道
        /// </summary>
        /// <param name="app"></param>
        public static void InitSwagger(this WebApplication app) 
       {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                typeof(ModuleGroupEnum).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"接口分类{version}");
                });
            });
       } 
    }
}
