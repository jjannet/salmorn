using Microsoft.Extensions.DependencyInjection;
using salmorn.IServices.Masters;
using salmorn.IServices.Transactions;
using salmorn.Services.Masters;
using salmorn.Services.Transactions;
using System;

namespace salmorn.Core
{
    public static class DependenciesMapper
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddCoreServices();
        }
    }
}
