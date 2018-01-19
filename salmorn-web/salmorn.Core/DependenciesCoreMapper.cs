using Microsoft.Extensions.DependencyInjection;
using salmorn.Core.GGClouds;
using salmorn.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace salmorn.Core
{
    public static class DependenciesCoreMapper
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IGGStorage, GGStorage>();
            services.AddTransient<IFileUploadProcess, FileUploadProcess>();
        }
    }
}
