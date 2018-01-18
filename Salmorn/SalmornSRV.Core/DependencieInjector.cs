using Microsoft.Extensions.DependencyInjection;
using SalmornSRV.Core.GoogleCloude;
using SalmornSRV.IDataAccess.Shop;
using SalmornSRV.IService.Log;
using SalmornSRV.IService.ManageShop;
using SalmornSRV.Service.Log;
using SalmornSRV.Service.ManageShop;
using SalmornSRV.Service.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalmornSRV.Core
{
    public static class DependencieInjector
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IGGStorage, GGStorage>();
            services.AddTransient<IUploadImage, UploadImage>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<IProductManageService, ProductManageService>();
            services.AddTransient<IOrderManageService, OrderManageService>();
        }
    }
}
