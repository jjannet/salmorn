using Microsoft.Extensions.DependencyInjection;
using salmorn.IServices.Masters;
using salmorn.Services.Masters;
using System;

namespace salmorn.Core
{
    public static class DependenciesMapper
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddTransient<IProductServices, ProductServices>();

            services.AddCoreServices();
        }
    }
}
