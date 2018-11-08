using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BethanysPieShop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BethanysPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // 运行时调用此方法。使用此方法将服务添加到容器。
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            //注册模拟数据
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            //注册mvc服务
            services.AddMvc();
        }

        // 运行时调用此方法。使用此方法配置 http 请求管道。
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //使用开发异常页
            app.UseDeveloperExceptionPage();
            //使用状态码
            app.UseStatusCodePages();
            //使用静态文件路径
            app.UseStaticFiles();
            ////使用mvc和默认路由方式
            //app.UseMvcWithDefaultRoute();
            //
            app.UseAuthentication();
            //
            app.UseMvc(
               route =>
               {
                   route.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
               }
            );
        }
    }
}
