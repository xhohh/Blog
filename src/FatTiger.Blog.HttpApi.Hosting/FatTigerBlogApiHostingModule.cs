using FatTiger.Blog.BackgroundJobs;
using FatTiger.Blog.BackgroundJobs.Jobs;
using FatTiger.Blog.Domain;
using FatTiger.Blog.HttpApi.Hosting.Filters;
using FatTiger.Blog.HttpApi.Hosting.Middleware;
using FatTiger.Blog.Swagger;
using FatTiger.Blog.ToolKits.Base;
using FatTiger.Blog.ToolKits.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FatTiger.Blog.HttpApi.Hosting
{
    [DependsOn(
       typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAutofacModule),
       typeof(FatTigerBlogHttpApiModule),
       typeof(FatTigerBlogSwaggerModule),
       typeof(FatTigerBlogFrameworkCoreModule),
       typeof(FatTigerBlogBackgroundJobsModule)
    )]
    public class FatTigerBlogApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //base.ConfigureServices(context);
            // 身份验证
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           //是否验证颁发者
                           ValidateIssuer = true,
                           //是否验证访问群体
                           ValidateAudience = true,
                           //是否验证生存期
                           ValidateLifetime = true,
                           //验证token的时间偏移量
                           ClockSkew = TimeSpan.FromSeconds(30),
                           //是否验证安全密钥
                           ValidateIssuerSigningKey = true,
                           //访问群体
                           ValidAudience = AppSettings.JWT.Domain,
                           //颁发者
                           ValidIssuer = AppSettings.JWT.Domain,
                           //安全密钥
                           IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                       };

                       //options.Events = new JwtBearerEvents
                       //{
                       //    OnChallenge = async context =>
                       //    {
                       //        context.HandleResponse();
                       //        context.Response.ContentType = "application/json;charset=utf-8";
                       //        context.Response.StatusCode = StatusCodes.Status200OK;

                       //        var result = new ServiceResult();
                       //        result.IsFailed("UnAuthorized");

                       //        await context.Response.WriteAsync(result.ToJson());
                       //    }
                       //};

                   });

            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                //添加自己实现的FatTigerBlogExceptionFilter
                options.Filters.Add(typeof(FatTigerBlogExceptionFilter));
            });

            // 认证授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();

            ////测试.net core内置定时任务处理方式
            //context.Services.AddTransient<IHostedService, HelloWorldJob>();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();

            //异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            //// HTTP => HTTPS
            //app.UseHttpsRedirection();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
