using System;
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
using Unity;

namespace ASPNETCoreIoCDI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IUnityContainer Container { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IDefaultDependency, MyDefaultClass1>();
            services.AddTransient<IMyDependency, MyClass2>();

            Unity.Microsoft.DependencyInjection.ServiceProvider serviceProvider =
                Unity.Microsoft.DependencyInjection.ServiceProvider.ConfigureServices(services)
                as Unity.Microsoft.DependencyInjection.ServiceProvider;

            ConfigureContainer(Container=(UnityContainer)serviceProvider);

            return serviceProvider;
        }
        public void ConfigureContainer(IUnityContainer container)
        {
            // Could be used to register more types
            container.RegisterType<IMyDependency, MyClass1>("MyClass1");
            //container.RegisterType<IMyDependency, MyClass2>(new Unity.Lifetime.SynchronizedLifetimeManager());
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
