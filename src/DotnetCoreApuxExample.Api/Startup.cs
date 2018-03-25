using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCoreApuxExample.Api.ActionDispatchers;
using DotnetCoreApuxExample.Api.ActionHandlers;
using DotnetCoreApuxExample.Api.Actions;
using DotnetCoreApuxExample.Api.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotnetCoreApuxExample.Api
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
            // Add the mock data as singletons
            services.AddSingleton<ICartDataAccess, CartDataAccess>();
            services.AddSingleton<IProductDataAccess, ProductDataAccess>();
            // Add Actions as a multi-service selector, using a factory function
            services.AddSingleton<IApuxActionRootDispatcher, RootActionDispatcher>();
            services.AddSingleton<AppErrorActionsDispatcher>();
            services.AddSingleton<CartActionDispatcher>();
            services.AddSingleton<ProductActionDispatcher>();
            services.AddSingleton(factory =>
            {
                Func<string, IApuxActionDispatcher> accessor = key =>
                {
                    switch (key)
                    {
                        case Constants.ActionNamespace.APP:
                            return factory.GetService<AppErrorActionsDispatcher>();
                        case Constants.ActionNamespace.CART:
                            return factory.GetService<CartActionDispatcher>();
                        case Constants.ActionNamespace.PRODUCT:
                            return factory.GetService<ProductActionDispatcher>();
                        default:
                            return factory.GetService<AppErrorActionsDispatcher>(); // will return an 'unknown action' response by default if no actions match
                    }
                };
                return accessor;
            });
            // Add Action handlers
            services.AddSingleton<IAppErrorActionHandler, AppErrorActionHandler>();
            services.AddSingleton<ICartActionHandler, CartActionHandler>();
            services.AddSingleton<IProductActionHandler, ProductActionHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
