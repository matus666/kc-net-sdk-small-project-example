using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KcNetSdkSmallProjectExample.Models;
using KcNetSdkSmallProjectExample.Resolvers;
using KenticoCloud.Delivery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KcNetSdkSmallProjectExample
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services
            .AddSingleton<IContentLinkUrlResolver, CustomContentLinkUrlResolver>()
            .AddSingleton<ITypeProvider, CustomTypeProvider>()
            .AddDeliveryClient(DeliveryOptionsBuilder.CreateInstance()
                .WithProjectId("09fc0115-dd4d-00c7-5bd9-5f73836aee81")
                .UseProductionApi
                .WithMaxRetryAttempts(5)
                .Build());

            // Equal expresison
            //services
            //    .AddSingleton(DeliveryClientBuilder
            //        .WithOptions(builder => builder
            //            .WithProjectId("09fc0115-dd4d-00c7-5bd9-5f73836aee81")
            //            .UseProductionApi
            //            .WithMaxRetryAttempts(5)
            //            .Build())
            //        .WithTypeProvider(new CustomTypeProvider())
            //        .WithContentLinkUrlResolver(new CustomContentLinkUrlResolver())
            //        .Build());

            // Here could be added Controller definition
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
